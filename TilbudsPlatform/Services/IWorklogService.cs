using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Services
{
    public interface IWorklogService
    {
        Task<Worklog> AddWorklogAsync(Worklog worklog);
        Task<IEnumerable<Worklog>> GetWorklogsByProjectIdAsync(int projectId);
    }
}
