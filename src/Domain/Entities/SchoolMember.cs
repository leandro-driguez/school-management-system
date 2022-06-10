using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class SchoolMember : Entity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string LastNames { get; set; }
        
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
    }
}
