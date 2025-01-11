using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Interfaces
{
    public interface IInvoiceInterface
    {
        Task<Invoice> GetByIdAsync(int id);
        Task<IEnumerable<Invoice>> GetByProjectIdAsync(int projectId);
    }
}
