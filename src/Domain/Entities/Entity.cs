
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities;

public class Entity
{
    public Entity(Guid id) { Id = id; }

    public Entity() { Id = Guid.NewGuid(); }

    [Key]
    public Guid Id { get; private protected set; }

    public override string ToString()
    {
        return Id.ToString();
    }
}
