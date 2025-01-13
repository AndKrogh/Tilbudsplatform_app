using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.Data;
using TilbudsPlatform.Entities;
using TilbudsPlatform.Interfaces;

namespace TilbudsPlatform.core.Services
{
    public class WorkTaskService : IWorkTaskInterface
    {
        private readonly TilbudsPlatformContext _context;

        public WorkTaskService(TilbudsPlatformContext context)
        {
            _context = context;
        }

        public async Task<WorkTask> GetByIdAsync(int id)
        {
            var workTask = await _context.WorkTasks.Include(w => w.Project).Include(w => w.Worklogs).FirstOrDefaultAsync(w => w.Id == id);
            if (workTask == null)
            {
                throw new KeyNotFoundException($"WorkTask with ID {id} not found.");
            }
            return workTask;
        }

        public async Task<IEnumerable<WorkTask>> GetByProjectIdAsync(int projectId)
        {
            return await _context.WorkTasks.Where(w => w.ProjectId == projectId).Include(w => w.Project).ToListAsync();
        }

        public async Task LogHoursAsync(int workTaskId, decimal hours, string description)
        {
            var workTask = await _context.WorkTasks.Include(w => w.Worklogs).FirstOrDefaultAsync(w => w.Id == workTaskId);
            if (workTask == null)
            {
                throw new KeyNotFoundException($"WorkTask with ID {workTaskId} not found.");
            }

            var worklog = new Worklog
            {
                WorkTaskId = workTaskId,
                HoursWorked = hours,
                Description = description,
                DateWorked = DateTime.Now
            };

            _context.Worklogs.Add(worklog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLoggedHoursAsync(int worklogId, decimal newHours, string newDescription)
        {
            var worklog = await _context.Worklogs.FirstOrDefaultAsync(w => w.Id == worklogId);
            if (worklog == null)
            {
                throw new KeyNotFoundException($"Worklog with ID {worklogId} not found.");
            }

            worklog.HoursWorked = newHours;
            worklog.Description = newDescription;
            await _context.SaveChangesAsync();
        }
    }
}
