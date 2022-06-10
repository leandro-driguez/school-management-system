using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Student_Service_Record
    {
        public Student Student { get; set; }
        public AditionalService Service { get; set; }
        public DateTime DateOfRequest { get; set; }
    }
}
