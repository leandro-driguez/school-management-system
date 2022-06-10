using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class ExpensesRelation : Entity
    {
        public Expense Expense { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int Value { get; set; }
    }
}
