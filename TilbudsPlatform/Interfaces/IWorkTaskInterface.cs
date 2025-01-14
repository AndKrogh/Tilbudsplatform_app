using TilbudsPlatform.Entities;

namespace TilbudsPlatform.core.Interfaces
{
    public interface IWorkTaskInterface
    {
        Task<IEnumerable<WorkTask>> GetAllWorkTasksAsync();
        Task<WorkTask> CreateAsync(WorkTask workTask);
        Task<IEnumerable<WorkTask>> GetByProjectIdAsync(int projectId);
        Task LogHoursAsync(int workTaskId, decimal hours, string description, int userId);
        Task UpdateLoggedHoursAsync(int worklogId, decimal newHours, string newDescription);
        Task<decimal> GetLoggedHoursAsync(int workTaskId);
        Task<decimal> GetEstimatedHoursAsync(int projectId);
        Task<string> GetUserNameAsync(int workTaskId);
        Task<DateTime?> GetLastLoggedDateAsync(int workTaskId);
    }
}
