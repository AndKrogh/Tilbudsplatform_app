namespace TilbudsPlatform.Interfaces
{
    public interface ITaskRepository
    {
        Task<Task> GetByIdAsync(int id);
        Task<IEnumerable<Task>> GetByProjectIdAsync(int projectId);
    }
}
