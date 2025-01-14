using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.core.Interfaces;
using TilbudsPlatform.Data;
using TilbudsPlatform.Entities;

namespace TilbudsPlatform.core.Services
{
    public class CustomerService : ICustomerInterface
    {
        private readonly TilbudsPlatformContext _context;

        public CustomerService(TilbudsPlatformContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> AddCustomerAsync(string name, string email)
        {
            var existingCustomer = await _context.Customers
                .Where(u => u.Email != null && u.Email.ToLower() == email.ToLower())
                .FirstOrDefaultAsync();

            if (existingCustomer != null)
            {
                throw new InvalidOperationException($"A customer with email '{email}' already exists.");
            }

            var newCustomer = new Customer
            {
                Name = name,
                Email = email
            };

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return newCustomer;
        }

        public async Task<bool> DeleteCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
