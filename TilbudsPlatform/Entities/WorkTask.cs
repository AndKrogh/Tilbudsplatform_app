using TilbudsPlatform.Model;

namespace TilbudsPlatform.Entities
{
    public class WorkTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal DurationHours { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<Worklog> Worklogs { get; set; }
    }
}
