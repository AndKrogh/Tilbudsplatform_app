using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.Data;
using TilbudsPlatform.Entities;
using TilbudsPlatform.Interfaces;

namespace Core.Services
{
    public class ICustomerService : ICustomerInterface
    {
        private readonly TilbudsPlatformContext _context;

        public ICustomerService(TilbudsPlatformContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            var customer = await GetCustomerByIdAsync(id);
            if (customer?.Id == null)
            {
                return null;
            }
            return await _context.Customers.FindAsync(customer.Id);
        }
    }
}
