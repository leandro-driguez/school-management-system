
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Expense : Entity
    {
        // [Required]
        // [MaxLength(20)]
        public string Category { get; set; }  

        // [Required]
        // [MaxLength(100)]
        public string Description { get; set; }
        
        public IList<ExpenseRecord> ExpenseRecords { get; set; }
    }
}
