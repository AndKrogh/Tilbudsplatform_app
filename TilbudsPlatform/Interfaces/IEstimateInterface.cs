using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Interfaces
{
    public interface IEstimateInterface
    {
        Task<Estimate> GetByProjectIdAsync(int projectId);
    }
}
