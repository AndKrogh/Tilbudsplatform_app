using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Interfaces
{
    public interface IEstimateRepository
    {
        Task<Estimate> GetByProjectIdAsync(int projectId);
    }
}
