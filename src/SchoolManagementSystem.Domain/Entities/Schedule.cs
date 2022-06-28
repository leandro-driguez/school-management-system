
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Schedule : Entity
    {
        // [Required]
        // [DataType(DataType.Time)]
        // [DisplayFormat(DataFormatString = "{0:hh-mm-ss}",
        //     ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        // [Required]
        // [DataType(DataType.Time)]
        // [DisplayFormat(DataFormatString = "{0:hh-mm-ss}",
        //     ApplyFormatInEditMode = true)]
        public DateTime StartTime{ get; set; }
        
        // [Required]
        // public DayOfWeek DayOfWeek { get; set; }
        
        public IList<Shift> Shifts { get; set; }
    }
}
