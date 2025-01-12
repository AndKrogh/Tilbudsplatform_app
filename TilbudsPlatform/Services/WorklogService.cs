using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Services
{
    public interface WorklogService
    {
        Task<Worklog> AddWorklogAsync(Worklog worklog);
        Task<IEnumerable<Worklog>> GetWorklogsByProjectIdAsync(int projectId);
    }
}
