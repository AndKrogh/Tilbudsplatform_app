using TilbudsPlatform.core.Entities;

namespace TilbudsPlatform.core.Interfaces
{
    public interface ICustomerInterface
    {
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> AddCustomerAsync(string name, string email);
        Task<bool> DeleteCustomerByIdAsync(int id);
    }

}
