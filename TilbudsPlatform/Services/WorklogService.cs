using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.core.Interfaces;
using TilbudsPlatform.Data;
using TilbudsPlatform.Entities;

public class WorklogService : IWorklogInterface
{
    private readonly TilbudsPlatformContext _context;

    public WorklogService(TilbudsPlatformContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Worklog>> GetAllWorklogsAsync()
    {
        return await _context.Worklogs.Include(w => w.WorkTask).Include(w => w.User).ToListAsync();
    }

    public async Task<Worklog> CreateAsync(Worklog worklog)
    {
        _context.Worklogs.Add(worklog);
        await _context.SaveChangesAsync();
        return worklog;
    }

    public async Task<Worklog> GetByIdAsync(int id)
    {
        var worklog = await _context.Worklogs.Include(w => w.WorkTask).Include(w => w.User).FirstOrDefaultAsync(w => w.Id == id);
        if (worklog == null) throw new KeyNotFoundException($"Worklog with ID {id} not found.");
        return worklog;
    }

    public async Task<IEnumerable<Worklog>> GetByWorkTaskIdAsync(int workTaskId)
    {
        return await _context.Worklogs.Where(w => w.WorkTaskId == workTaskId).ToListAsync();
    }
}
