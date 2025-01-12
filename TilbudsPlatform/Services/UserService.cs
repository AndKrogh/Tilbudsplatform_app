using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Services
{
    public interface UserService
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
