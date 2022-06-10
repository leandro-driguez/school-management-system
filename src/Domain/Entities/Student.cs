using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Range(0,999999)]
        public int Founds { get; set; }
        
        [Required]
        public Education ScholarityLevel{ get; set; }
        public Guid TuitorId { get; set; }
    }
}
