
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Domain.Entities
{ 
    public class CourseGroup : Entity
    {
        // [Key]
        // [Required]
        // [ForeignKey("CourseFK")]
        public Course Course { get; set; }

        // [Key]
        // [Required]
        // [ForeignKey("WorkerFK")]
        public Teacher Teacher{ get; set; }

        // [Required]
        // [Range(5,30)]
        public int Capacity { get; set; }

        // [Required]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        //                ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; } //= DateTime.Now();

        // [Required]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        //                ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        // [Required]
        // public IList<Shift> Shifts { get; set; }
        
        // [Required]
        // public ICollection<Student> Students { get; set; }
    }
}
