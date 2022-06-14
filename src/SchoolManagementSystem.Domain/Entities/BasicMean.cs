
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Domain.Entities
{
    public class BasicMean : Entity
    {
        // [Required]
        // [Range(1,99999)]
        // [DataType(DataType.Currency)]
        // [Column(TypeName = "money")]
        public int Price { get; set; }
        
        // [Required]
        // [MaxLength(20)]
        public string Type{ get; set; }
        
        // [Required]
        // [MaxLength(30)]
        public string Origin{ get; set; }
        
        // [Required]
        public int DevaluationInTime{ get; set; }
        
        // [Required]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        //                ApplyFormatInEditMode = true)]
        public DateTime InaugurationDate{ get; set; }
        
        // [Required]
        // [MaxLength(100)]
        public string Description{ get; set; }
    }
}
