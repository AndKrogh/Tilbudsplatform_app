namespace TilbudsPlatform.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public ICollection<Worklog> Worklogs { get; set; }

        public ICollection<WorkTask> WorkTasks { get; set; }
    }
}
