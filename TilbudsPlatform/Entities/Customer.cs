using TilbudsPlatform.Model;

namespace TilbudsPlatform.Entities
{
    public class Customer
    {
        required public int Id { get; set; }
        required public string Name { get; set; }
        required public string Email { get; set; }
        required public string Phone { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
