using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class CourseShift
    {
        public List<Shift> Shifts { get; set; }
        
    } 
    public class CourseGroup : Entity
    {
        public Course Course { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Worker CurrentTeacher{ get; set; }
        public CourseShift  Shift{ get; set; }
    }
}
