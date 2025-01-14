using TilbudsPlatform.Entities;

namespace TilbudsPlatform.core.Interfaces
{
    public interface IWorklogInterface
    {
        Task<IEnumerable<Worklog>> GetAllWorklogsAsync();
        Task<Worklog> GetByIdAsync(int id);
        Task<IEnumerable<Worklog>> GetByWorkTaskIdAsync(int WorkTaskId);
        Task<Worklog> CreateAsync(Worklog worklog);
    }
}
