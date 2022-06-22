
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class CourseDto : IDto
{
    public string Id { get; set; }

    [Required]
    public int Price { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string Name { get; set; }
}
