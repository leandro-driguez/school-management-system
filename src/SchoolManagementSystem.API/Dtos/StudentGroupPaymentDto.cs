

using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.API.Dtos;


public class StudentGroupPaymentDto
{
    [Required]
    public string StudentId { get; set; }
    [Required]
    public string GroupId { get; set; }
    [Required]
    public string CourseGroupCourseId { get; set; }
}