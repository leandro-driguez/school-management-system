
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class StudentPayCourseRecordDto
{

    public string StudentId { get; set; }
    public Student Student { get; set; }

    public string CourseGroupId { get; set; }
    public string CourseGroupCourseId { get; set; }
    public CourseGroup CourseGroup { get; set; }
    public DateTime DatePaid { get; set; }

}
