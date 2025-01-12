using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal EstimatedHours { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal ProfitMargin { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Worklog> Worklog { get; set; }
        public Estimate Estimate { get; set; }
        public ICollection<WorkTask> WorkTasks { get; set; }
    }
}
