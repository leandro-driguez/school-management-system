
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Records
{
    public class StudentPaymentRecordForAdditionalService : Entity
    {
        [Required]
        public Student Student { get; set; }
        
        [Required]
        public AdditionalService Service { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
