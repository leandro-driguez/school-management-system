
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Relations;

public class WorkerResourceRelation : Entity
{
    [Required]
    public Worker Worker { get; set; }

    [Required]
    public Resource Resource { get; set; }

    [Required]
    [Range(1,100)]
    public int CorrespondingPorcentage { get; set; }
}
