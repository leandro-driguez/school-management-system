using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public enum Education
    {
        Preuniversitario,
        Secundaria,
        Primaria,
        Tecnico_Medio,
        Escuela_Oficios,
        Universitario,
        Posgrado

    }

    public class Student : SchoolMember
    {
        public int Founds { get; set; }
        public Education ScholarityLevel{ get; set; }

        public Tuitor Tuitor { get; set; }
    }
}
