
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Records;

public class StudentPaymentRecordPerCourseGroup : Record
{
    [Required]
    public Student Student { get; set; }
    
    [Required]
    public CourseGroup PaidGroup { get; set; }
}
