using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Interfaces
{
    public interface IWorklogInterface
    {
        Task<Worklog> GetByIdAsync(int id);
        Task<IEnumerable<Worklog>> GetByProjectIdAsync(int projectId);
    }
}
