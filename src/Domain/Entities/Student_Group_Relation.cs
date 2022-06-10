using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Student_Group_Relation : Entity
    {
        public Guid StudentId { get; set; }
        public Guid CourseGroupId { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate{ get; set; }
    }
}
