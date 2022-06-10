
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities;

public class Charges : Entity
{
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }
}
