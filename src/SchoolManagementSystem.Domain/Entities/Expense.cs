
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Expense : Entity
    {
        [Required]
        [MaxLength(20)]
        public string Category { get; set; }  

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
