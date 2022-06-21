
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.API.Dtos;

public class ClassroomDto : IDto
{
    public string Id { get; set; }

    [Required]
    [MaxLength(10)]
    public string Name {get; set;}

    [Required]
    [Range(5, 30)]
    public int Capacity { get; set; }
}
