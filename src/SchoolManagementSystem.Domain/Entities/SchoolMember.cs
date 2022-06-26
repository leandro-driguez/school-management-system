
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class SchoolMember : Entity
    {
        private protected string _id;
        public string Type { get; set; }

        // [Required]

        public string IdCardNo {get; set;}

        // [Required]
        // [MaxLength(20)]
        public string Name { get; set; }
        
        // [Required]
        // [MaxLength(30)]
        public string LastName { get; set; }
        
        // [Required]
        public int PhoneNumber{ get; set; }
        
        // [Required]
        // [MaxLength(50)]
        public string Address { get; set; }
        
        // [Required]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        //                ApplyFormatInEditMode = true)]
        // [Display(Name = "Date Becomed Member")]
        public DateTime DateBecomedMember { get; set; }
    }
}
