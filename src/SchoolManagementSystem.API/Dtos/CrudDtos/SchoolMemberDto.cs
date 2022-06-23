
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class SchoolMemberDto : IDto
{
     private protected string _id;

        [Required]
        [StringLength(11)]
        public string Id {get; set;}

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        
        [Required]
        public int PhoneNumber{ get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Date Becomed Member")]
        public DateTime DateBecomedMember { get; set; }

        public IList<Position> Positions { get; set; }
}
