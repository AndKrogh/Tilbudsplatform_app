using TilbudsPlatform.Model;

namespace TilbudsPlatform.Entities
{
    public class Estimate
    {
        required public int Id { get; set; }
        required public decimal EstimatedHours { get; set; }
        required public decimal HourlyRate { get; set; }
        required public decimal TotalCost { get; set; }
        required public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
