
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Enums;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Student : SchoolMember
    {
        public Tuitor Tuitor { get; set; }
        public int Founds { get; set; }   
        public Education ScholarityLevel{ get; set; }
        
        // [Required]
        // public IList<CourseGroup> Groups { get; set; }
    }
}
