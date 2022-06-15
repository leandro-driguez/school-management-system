
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Records;

public class StudentPaymentRecordForAdditionalService : Record
{
    // [Required]
    public string StudentId { get; set; }
    public Student Student { get; set; }
    
    // [Required]
    public string AdditionalServiceWorkerId { get; set; }
    public string AdditionalServiceResourceId { get; set; }
    public AdditionalService AdditionalService { get; set; }
}
