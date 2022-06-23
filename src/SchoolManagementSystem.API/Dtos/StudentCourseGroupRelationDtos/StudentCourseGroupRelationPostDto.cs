
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
    [MinLength(1)]
    public List<string> StudentsId{get; set;}
}

