
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class StudentPayCourseRecordDto
{

    //[Required]
    //public string StudentId { get; set; }
    [Required]
    public DateTime Date { get; set; }
    //[Required]
    //public string CourseGroupId { get; set; }
    [Required]
    public string CourseGroupId { get; set; }
    [Required]
    public int CourseGroupCoursePrice { get; set; }

}
