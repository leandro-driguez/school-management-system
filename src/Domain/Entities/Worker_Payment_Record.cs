using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Worker_Payment_Record : Entity
    {
        public Worker Worker { get; set; }
        public int Payment { get; set; }
        public DateTime Date { get; set; }
    }
}
