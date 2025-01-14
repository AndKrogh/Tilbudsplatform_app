using TilbudsPlatform.Entities;

namespace TilbudsPlatform.core.Interfaces
{
    public interface IUserInterface
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
