using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Resource : Entity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price{ get; set; }
    }
}
