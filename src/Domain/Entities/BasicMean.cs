using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    internal class BasicMean
    {
        public int Price { get; set; }
        public string Type{ get; set; }
        public string Origin{ get; set; }
        public int DevaluationInTime{ get; set; }
        public DateTime InaugurationDate{ get; set; }
        public string Description{ get; set; }
    }
}
