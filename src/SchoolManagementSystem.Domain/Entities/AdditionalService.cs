
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Domain.Entities
{
    public class AdditionalService
    {
        public string WorkerId { get; set; }
        public Worker Worker { get; set; }
        
        public string ResourceId { get; set; }
        public Resource Resource { get; set; }

        public int WorkerPorcentageProfits { get; set; }
    }
}
