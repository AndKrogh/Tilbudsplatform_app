using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
    }

}
