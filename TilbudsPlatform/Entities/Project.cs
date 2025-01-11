using TilbudsPlatform.Entities;

namespace TilbudsPlatform.Model
{
    public class Project
    {
        required public int Id { get; set; }
        required public string Name { get; set; }
        public string? Description { get; set; }
        required public DateTime StartDate { get; set; }
        required public DateTime EndDate { get; set; }
        required public decimal EstimatedHours { get; set; }
        required public decimal HourlyRate { get; set; }
        required public decimal ProfitMargin { get; set; }
        required public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Worklog> Worklog { get; set; }
        public Estimate Estimate { get; set; }
    }
}
