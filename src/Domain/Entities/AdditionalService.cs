
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class AdditionalService : Entity
    {
        [Required]
        public Worker Worker { get; set; }
        
        [Required]
        public Resource Resource { get; set; }

        [Required]
        [Range(0, 100)]
        public int WorkerPorcentageProfits { get; set; }
    }
}
