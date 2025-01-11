using TilbudsPlatform.Model;

namespace TilbudsPlatform.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetByIdAsync(int id);
        Task<IEnumerable<Project>> GetAllAsync();
    }
}
