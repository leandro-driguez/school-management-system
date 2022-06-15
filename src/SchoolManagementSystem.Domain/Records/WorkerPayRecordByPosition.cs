
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Records;

public class WorkerPayRecordByPosition : Record
{
    // [Required]
    public string WorkerId { get; set; }
    public Worker Worker { get; set; }

    // [Required]
    public string PositionId { get; set; }
    public Position Position { get; set; }

    // [Required]
    // [Range(1,99999)]
    // [DataType(DataType.Currency)]
    // [Column(TypeName = "money")]
    public int Payment { get; set; }
}
