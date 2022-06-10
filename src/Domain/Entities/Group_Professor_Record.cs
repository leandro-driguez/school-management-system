using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Group_Professor_Record : Entity
    {
        public Worker Professor{ get; set; }
        public CourseGroup Group { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate{ get; set; }

    }
}
