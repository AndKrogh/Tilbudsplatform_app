using TilbudsPlatform.Model;

namespace TilbudsPlatform.core.Interfaces
{
    public interface IProjectInterface
    {
        Task<Project> CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int id);
        Task<Project> GetProjectByIdAsync(int id);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
    }
}
