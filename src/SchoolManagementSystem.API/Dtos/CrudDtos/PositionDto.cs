
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class PositionDto : IDto
{
    public string Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; }
}
