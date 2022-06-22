
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;
public class BasicMeanDto : IDto
{
    public string Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Type { get; set; }

    [Required]
    [MaxLength(30)]
    public string Origin { get; set; }

    [Required]
    public int DevaluationInTime { get; set; }

    // [Required]
    // [DataType(DataType.Date)]
    // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
    //               ApplyFormatInEditMode = true)]
    // public DateTime InaugurationDate { get; set; }

    // [Required]
    // [MaxLength(100)]
    // public string Description { get; set; }
}