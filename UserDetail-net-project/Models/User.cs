using System.ComponentModel.DataAnnotations.Schema;

namespace UserDetail_.net_project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        [NotMapped]
        public DateOnly CreatedDate { get; set; }
        [NotMapped]
        public DateOnly DOB { get; set; }
    }
}
