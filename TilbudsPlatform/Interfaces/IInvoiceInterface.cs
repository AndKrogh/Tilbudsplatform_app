using TilbudsPlatform.Entities;

namespace TilbudsPlatform.core.Interfaces
{
    public interface IInvoiceInterface
    {
        Task<Invoice> GetByIdAsync(int id);
        Task<IEnumerable<Invoice>> GetByProjectIdAsync(int projectId);
    }
}
