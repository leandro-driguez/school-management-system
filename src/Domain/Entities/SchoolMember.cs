using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class SchoolMember : Entity
    {
        public string Name { get; set; }
        public string LastNames { get; set; }
        public int PhoneNumber{ get; set; }
        public string Address { get; set; }
        public DateTime DateBecomedMeber { get; set; }
    }
}
