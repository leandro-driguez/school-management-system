using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Tuitor : Entity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        public int PhoneNumber { get; set; }
    }
}
