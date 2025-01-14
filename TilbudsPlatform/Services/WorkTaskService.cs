using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.Data;
using TilbudsPlatform.Entities;
using TilbudsPlatform.Interfaces;

public class WorkTaskService : IWorkTaskInterface
{
    private readonly TilbudsPlatformContext _context;

    public WorkTaskService(TilbudsPlatformContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WorkTask>> GetAllWorkTasksAsync()
    {
        return await _context.WorkTasks.Include(w => w.Project).ToListAsync();
    }

    public async Task<WorkTask> CreateAsync(WorkTask workTask)
    {
        _context.WorkTasks.Add(workTask);
        await _context.SaveChangesAsync();
        return workTask;
    }

    public async Task<IEnumerable<WorkTask>> GetByProjectIdAsync(int projectId)
    {
        return await _context.WorkTasks
            .Where(w => w.ProjectId == projectId)
            .Include(w => w.Project)
            .ToListAsync();
    }

    public async Task LogHoursAsync(int workTaskId, decimal hours, string description, int userId)
    {
        var workTask = await _context.WorkTasks
            .Include(w => w.Worklogs)
            .FirstOrDefaultAsync(w => w.Id == workTaskId);

        if (workTask == null)
        {
            throw new ArgumentException("Work task not found.");
        }

        var worklog = new Worklog
        {
            WorkTaskId = workTaskId,
            HoursWorked = hours,
            Description = description,
            DateWorked = DateTime.UtcNow,
            UserId = userId
        };

        workTask.Worklogs.Add(worklog);

        workTask.TotalLoggedHours += hours;
        workTask.LastLoggedDate = DateTime.UtcNow;

        var user = await _context.Users
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (user != null)
        {
            workTask.LastLoggedUserName = $"{user.FirstName} {user.LastName}";
        }

        await _context.SaveChangesAsync();
    }


    public async Task UpdateLoggedHoursAsync(int worklogId, decimal newHours, string newDescription)
    {
        var worklog = await _context.Worklogs.FirstOrDefaultAsync(w => w.Id == worklogId);

        if (worklog == null)
            throw new ArgumentException("Worklog not found.");

        worklog.HoursWorked = newHours;
        worklog.Description = newDescription;

        await _context.SaveChangesAsync();
    }

    public async Task<decimal> GetLoggedHoursAsync(int workTaskId)
    {
        var workTask = await _context.WorkTasks
            .Include(w => w.Worklogs)
            .FirstOrDefaultAsync(w => w.Id == workTaskId);

        if (workTask == null)
            throw new ArgumentException("Work task not found.");

        return workTask.Worklogs.Sum(wl => wl.HoursWorked);
    }

    public async Task<decimal> GetEstimatedHoursAsync(int projectId)
    {
        var project = await _context.Projects
            .Where(p => p.Id == projectId)
            .Include(p => p.WorkTasks)
            .FirstOrDefaultAsync();

        if (project == null)
            throw new ArgumentException("Project not found.");

        return project.WorkTasks.Sum(wt => wt.DurationHours);
    }

    public async Task<string> GetUserNameAsync(int workTaskId)
    {
        var workTask = await _context.WorkTasks
            .Include(w => w.Worklogs)
            .ThenInclude(wl => wl.User)
            .FirstOrDefaultAsync(w => w.Id == workTaskId);

        if (workTask == null)
            throw new ArgumentException("Work task not found.");

        var lastWorklog = workTask.Worklogs.OrderByDescending(wl => wl.DateWorked).FirstOrDefault();
        return lastWorklog?.User != null ? $"{lastWorklog.User.FirstName} {lastWorklog.User.LastName}" : "Unknown User";
    }

    public async Task<DateTime?> GetLastLoggedDateAsync(int workTaskId)
    {
        var workTask = await _context.WorkTasks
            .Include(w => w.Worklogs)
            .FirstOrDefaultAsync(w => w.Id == workTaskId);

        if (workTask == null)
            throw new ArgumentException("Work task not found.");

        return workTask.Worklogs.OrderByDescending(wl => wl.DateWorked).FirstOrDefault()?.DateWorked;
    }
}
