
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Course : Entity
    {
        // [Required]
        // [Range(1,99999)]
        // [DataType(DataType.Currency)]
        // [Column(TypeName = "money")]
        public int Price { get; set; }
        
        // [Required]
        // [MaxLength(20)]
        public string Type { get; set; }
        
        // [Required]
        // [MaxLength(20)]
        public string Name { get; set; }

    }
}
