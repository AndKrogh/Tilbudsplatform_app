using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.core.Data;
using TilbudsPlatform.core.Interfaces;
using TilbudsPlatform.Entities;

namespace TilbudsPlatform.core.Services
{
    public class UserService : IUserInterface
    {
        private readonly TilbudsPlatformContext _context;

        public UserService(TilbudsPlatformContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Role))
            {
                throw new ArgumentException("All user fields must be provided.");
            }

            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                throw new InvalidOperationException($"A user with the email {user.Email} already exists.");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
