using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public enum ExpenseCategory
    {

    }
    public class Expense : Entity
    {
        public ExpenseCategory Category { get; set; }  
        public string Description { get; set; }

    }
}
