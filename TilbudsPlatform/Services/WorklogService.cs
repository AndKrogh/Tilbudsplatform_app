using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.Data;
using TilbudsPlatform.Entities;
using TilbudsPlatform.Interfaces;

namespace TilbudsPlatform.core.Services
{
    public class WorklogService : IWorklogInterface
    {
        private readonly TilbudsPlatformContext _context;
        private readonly IWorkTaskInterface _workTaskService;

        public WorklogService(TilbudsPlatformContext context, IWorkTaskInterface workTaskService)
        {
            _context = context;
            _workTaskService = workTaskService;
        }

        public async Task<IEnumerable<Worklog>> GetAllWorklogsAsync()
        {
            return await _context.Worklogs
                .Include(w => w.WorkTask)
                .Include(w => w.User)
                .ToListAsync();
        }

        public async Task<Worklog> GetByIdAsync(int id)
        {
            var worklog = await _context.Worklogs
                .Include(w => w.WorkTask)
                .Include(w => w.User)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (worklog == null)
            {
                throw new KeyNotFoundException($"Worklog with ID {id} not found.");
            }

            return worklog;
        }

        public async Task<IEnumerable<Worklog>> GetByWorkTaskIdAsync(int workTaskId)
        {
            return await _context.Worklogs
                .Where(w => w.WorkTaskId == workTaskId)
                .ToListAsync();
        }

        public async Task<Worklog> CreateAsync(Worklog worklog)
        {
            if (string.IsNullOrWhiteSpace(worklog.Description))
            {
                throw new ArgumentException("Description cannot be null or empty.");
            }

            if (worklog.DateWorked == default)
            {
                throw new ArgumentException("A valid DateWorked is required.");
            }

            if (worklog.HoursWorked <= 0)
            {
                throw new ArgumentException("HoursWorked must be greater than zero.");
            }

            if (worklog.WorkTaskId == 0 && worklog.WorkTask == null)
            {
                throw new ArgumentException("A valid WorkTask or WorkTaskId is required.");
            }

            if (worklog.WorkTaskId == 0 && !string.IsNullOrEmpty(worklog.WorkTask?.Title))
            {
                var newWorkTask = new WorkTask { Title = worklog.WorkTask.Title };
                await _workTaskService.CreateAsync(newWorkTask);
                worklog.WorkTaskId = newWorkTask.Id;
            }

            _context.Worklogs.Add(worklog);
            await _context.SaveChangesAsync();
            return worklog;
        }
    }
}
