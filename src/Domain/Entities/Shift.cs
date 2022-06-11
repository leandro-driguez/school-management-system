
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Shift : Entity
    {
        [Required]
        public Classroom ShiftClassroom { get; set; }
        
        [Required]
        public Schedule ShiftSchedule { get; set; }
    }
}
