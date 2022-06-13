
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Domain.Entities
{
    public class AdditionalService : Entity
    {
        [Key]
        [Required]
        [ForeignKey("WorkerFK")]
        public Worker Provider { get; set; }
        
        [Key]
        [Required]
        [ForeignKey("ResourceFK")]
        public Resource Resource { get; set; }

        [Required]
        [Range(0, 100)]
        public int WorkerPorcentageProfits { get; set; }
    }
}
