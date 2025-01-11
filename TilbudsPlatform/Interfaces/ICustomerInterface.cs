using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Interfaces
{
    public interface ICustomerInterface
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
    }
}
