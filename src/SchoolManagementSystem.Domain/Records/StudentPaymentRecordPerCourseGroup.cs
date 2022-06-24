
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Records;

public class StudentPaymentRecordPerCourseGroup : Record
{
    public string StudentId { get; set; }
    public Student Student { get; set; }
    
    public string CourseGroupId { get; set; }
    public string CourseGroupCourseId { get; set; }
    public CourseGroup CourseGroup { get; set; }
    public DateOnly DatePaid { get; set; }
}
