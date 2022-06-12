
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Domain.Entities
{
    public class AdditionalService : Entity
    {
        // public AdditionalService(Worker provider, Resource resource, int workerPorcentageProfits) 
        //     : base(new Guid((string)provider.ToString().Concat(resource.ToString())))
        // {
        //     Provider = provider;
        //     Resource = resource;
        //     WorkerPorcentageProfits = workerPorcentageProfits;
        // }

        // public override Guid Id { 
        //     get{
        //         Tuple<Guid,Guid> fKeys = new Tuple<Guid,Guid>(Worker.Id,Resource.Id);
        //         return new Guid(fKeys.ToString());
        //     } 
        // }

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
