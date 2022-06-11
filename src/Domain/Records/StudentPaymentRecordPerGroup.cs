
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Records
{
    public class StudentPaymentRecordPerGroup : Entity
    {
        [Required]
        public Student Student { get; set; }
        
        [Required]
        public CourseGroup PaidCourseGroup { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }
    }
    
}
