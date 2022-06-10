using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public enum Position
    {
        Administrador,
        Jefe,
        Secretario
    }

    public class Worker : SchoolMember
    {
        public List<Position> Positions{ get; set; }

        public int FixNetSalary{ get; set; }

        public Dictionary<Position, int>  FixSalaryPerPosition{ get; set; }
    }
}
