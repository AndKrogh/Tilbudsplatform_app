using TilbudsPlatform.Model;

namespace TilbudsPlatform.Entities
{
    public class Estimate
    {
        public int Id { get; set; }
        public decimal EstimatedHours { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalCost { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
