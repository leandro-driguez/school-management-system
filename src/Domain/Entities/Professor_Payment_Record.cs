using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    internal class Professor_Payment_Record
    {
        public Worker Professor { get; set; }
        public Course PaidCourse{ get; set; }
        public DateTime Date { get; set; }
        public int CorrespondingPorcentage { get; set; }

    }
}
