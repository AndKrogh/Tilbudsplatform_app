using TilbudsPlatform.Entities;

namespace TilbudsPlatform.core.Interfaces
{
    public interface IEstimateInterface
    {
        Task<Estimate> GetByProjectIdAsync(int projectId);
        Task<int?> GetEstimateByProjectIdAsync(int projectId);
    }
}
