
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Records
{
    public class WorkerPayRecordByPosition : Entity
    {
        [Required]
        public Worker Worker { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        [Range(1,99999)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public int Payment { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
