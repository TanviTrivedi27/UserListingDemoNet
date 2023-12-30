using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalEntity
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        [NotMapped]
        public DateTime? CreatedDate { get; set; }
        [NotMapped]
        public DateTime? DOB { get; set; }
        public string? Gender { get; set; }
        public string? Skills { get; set; }
        public bool? Subscribe { get; set; }
        public int? Year { get; set; }
    }
}