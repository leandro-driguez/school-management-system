
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Relations;

public class WorkerPositionRelation : Entity
{
    [Required]
    public Worker Worker { get; set; }

    [Required]
    public Position Position { get; set; }

    [Required]
    [Range(1, 99999)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "money")]
    public int FixedSalary { get; set; }
}
