
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities;

public class Position : Entity
{
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }

    // [Required]
    // public IList<Worker> Workers { get; set; }
}
