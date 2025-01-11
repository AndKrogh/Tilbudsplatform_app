using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Interfaces
{
    public interface ICustomerInterface
    {
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> AddCustomerAsync(string name, string email);
    }

}
