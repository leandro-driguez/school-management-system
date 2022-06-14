
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities;

public class Classroom : Entity
{
    // [Required]
    // [MaxLength(10)]
    public string Name {get; set;}

    // [Required]
    // [Range(5, 30)]
    public int Capacity { get; set; }
    
    public IList<Shift> Shifts { get; set; }
}
