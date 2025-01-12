namespace TilbudsPlatform.Entities
{
    public class Worklog
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal HoursWorked { get; set; }

        public DateTime DateWorked { get; set; }

        public int WorkTaskId { get; set; }

        public WorkTask WorkTask { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
