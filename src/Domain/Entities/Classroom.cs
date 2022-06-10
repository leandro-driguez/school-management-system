
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities;

public class Classroom : Entity
{
    [Required]
    [MaxLength(10)]
    public string Name {get; set;}

    [Required]
    public int Capacity { get; set; }
}
