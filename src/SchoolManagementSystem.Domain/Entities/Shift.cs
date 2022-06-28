
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Shift 
    {
        public string ClassroomId { get; set; }
        
        public Classroom Classroom { get; set; }
        
        public string ScheduleId { get; set; }
        
        public Schedule Schedule { get; set; }

        public CourseGroup Group {get; set; }
        
        public string Description{get; set;} 
    }
}
