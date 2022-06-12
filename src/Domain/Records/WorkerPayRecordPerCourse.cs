
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Records
{
    public class WorkerPayRecordPerCourse : Entity
    {
        [Required]
        public Worker Teacher { get; set; }
        
        [Required]
        public Course PaidCourse{ get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        
        [Required]
        [Range(1,100)]
        public int PaidPorcentage { get; set; }
    }
}
