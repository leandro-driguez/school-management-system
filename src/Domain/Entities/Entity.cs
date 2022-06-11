
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities;

public class Entity
{
    [Key]
    public virtual Guid Id { get; set; } = Guid.NewGuid();
}
