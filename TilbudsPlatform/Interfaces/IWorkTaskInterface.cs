using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Interfaces
{
    public interface IWorkTaskInterface
    {
        Task<IEnumerable<WorkTask>> GetAllWorkTasksAsync();
        Task<WorkTask> CreateAsync(WorkTask workTask);
        Task<IEnumerable<WorkTask>> GetByProjectIdAsync(int projectId);
        Task LogHoursAsync(int workTaskId, decimal hours, string description);
        Task UpdateLoggedHoursAsync(int worklogId, decimal newHours, string newDescription);
    }
}
