

using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Relations;

public class TeacherCourseRelation : Entity
{
    [Required]
    public Worker Teacher { get; set; }
    
    [Required]
    public Course PaidCourse{ get; set; }
    
    [Required]
    [Range(1,100)]
    public int CorrespondingPorcentage { get; set; }
}