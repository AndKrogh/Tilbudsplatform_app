using TilbudsPlatform.Model;

namespace TilbudsPlatform.Services
{
    public interface IProjectService
    {
        Task<Project> CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int id);
        Task<Project> GetProjectByIdAsync(int id);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
    }
}
