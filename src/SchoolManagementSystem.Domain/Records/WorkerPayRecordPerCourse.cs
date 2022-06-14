
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Records;

public class WorkerPayRecordPerCourse : Record
{
    [Required]
    public Worker Teacher { get; set; }
    
    [Required]
    public Course PaidCourse{ get; set; }
    
    [Required]
    [Range(1,100)]
    public int PaidPorcentage { get; set; }
}
