using TilbudsPlatform.Model;

namespace TilbudsPlatform.Entities
{
    public class Worklog
    {
        required public int Id { get; set; }
        required public string Title { get; set; }
        required public string Description { get; set; }
        required public DateTime LoggedDate { get; set; }
        required public decimal HoursWorked { get; set; }
        required public int ProjectId { get; set; }
        required public int UserId { get; set; } 
        public User User { get; set; }
    }
}
