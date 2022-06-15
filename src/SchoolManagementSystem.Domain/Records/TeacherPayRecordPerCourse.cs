
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Records;

public class TeacherPayRecordPerCourse : Record
{
    // [Required]
    public string TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    
    // [Required]
    public string CourseId { get; set; }
    public Course Course { get; set; }
    
    // [Required]
    // [Range(1,100)]
    public int PaidPorcentage { get; set; }
}
