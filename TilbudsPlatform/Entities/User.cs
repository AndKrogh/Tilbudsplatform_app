﻿namespace TilbudsPlatform.Entities
{
    public class User
    {
        required public int Id { get; set; }
        required public string FirstName { get; set; }
        required public string LastName { get; set; }
        required public string Email { get; set; }
        required public string Role { get; set; }
        public ICollection<Worklog> Worklog { get; set; }
    }
}
