using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Shift : Entity
    {
        public Classroom ShiftClassroom { get; set; }
        public Schedule ShiftSchedule { get; set; }
    }
}
