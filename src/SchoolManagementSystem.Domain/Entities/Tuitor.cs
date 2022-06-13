
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Tuitor : Entity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        public int PhoneNumber { get; set; }
    }
}
