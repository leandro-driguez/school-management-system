
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.API.Dtos;

public class WorkerPositionRelationDto
{
    [Required]
    public string WorkerId { get; set; }
    // [Required]
    public string WorkerName { get; set; }
    [Required]
    public string PositionId { get; set; }
    // [Required]
    public string PositionName { get; set; }
    // [Required]
    public int FixedSalary { get; set; }
}

