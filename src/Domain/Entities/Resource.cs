using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Resource : Entity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Category { get; set; }
        
        [Required]
        [Range(1,999999)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public int Price{ get; set; }
    }
}
