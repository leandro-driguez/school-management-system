
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{ 
    public class CourseGroup : Entity
    {
        [Required]
        public Course Course { get; set; }

        [Required]
        [Range(5,30)]
        public int Capacity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; } //= DateTime.Now();

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        
        [Required]
        public Worker CurrentTeacher{ get; set; }
        
        [Required]
        public ICollection<Student> Students { get; set; }

        [Required]
        public IList<Shift> Shifts { get; set; }
    }
}
