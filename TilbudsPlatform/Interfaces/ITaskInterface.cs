namespace TilbudsPlatform.Interfaces
{
    public interface ITaskInterface
    {
        Task<Task> GetByIdAsync(int id);
        Task<IEnumerable<Task>> GetByProjectIdAsync(int projectId);
    }
}
