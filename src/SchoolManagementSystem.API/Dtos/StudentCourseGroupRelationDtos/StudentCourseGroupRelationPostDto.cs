
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.API.Dtos;

public class StudentCourseGroupRelationPostDto
{
    [Required]
    public string CourseGroupId { get; set; }
    [Required]
    public string CourseId { get; set; }
    [Required]
    public string StudentId{get; set;}
    // [Required]
    public DateTime StartDate {get; set;}
    // [Required]
    public DateTime EndDate {get; set;}
}

