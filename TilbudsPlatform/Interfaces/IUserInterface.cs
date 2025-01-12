using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Interfaces
{
    public interface IUserInterface
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
