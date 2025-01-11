using TilbudsPlatform.Model;

namespace TilbudsPlatform.Interfaces
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
