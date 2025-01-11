using TilbudsPlatform.Model;

namespace TilbudsPlatform.Entities
{
    public class Task
    {
        required public int Id { get; set; }
        required public string Title { get; set; }
        required public string Description { get; set; }
        required public decimal DurationHours { get; set; }
        required public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
