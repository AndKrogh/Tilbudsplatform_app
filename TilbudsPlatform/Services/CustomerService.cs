using TilbudsPlatform.Entities;
using TilbudsPlatform.Interfaces;

namespace TilbudsPlatform.core.Services
{
    public class CustomerService : ICustomerInterface
    {
        private readonly List<Customer> _customers = new();

        public async Task<Customer> GetByIdAsync(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id) ?? throw new KeyNotFoundException("Customer not found.");
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return _customers;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            // Assign a new unique ID to the customer
            customer.Id = _customers.Count > 0 ? _customers.Max(c => c.Id) + 1 : 1;

            _customers.Add(customer);
            return customer;
        }
    }
}
