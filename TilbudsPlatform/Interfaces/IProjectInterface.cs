using TilbudsPlatform.Model;

namespace TilbudsPlatform.Interfaces
{
    public interface IProjectInterface
    {
        Task<Project> GetByIdAsync(int id);
        Task<IEnumerable<Project>> GetAllAsync();
    }
}
