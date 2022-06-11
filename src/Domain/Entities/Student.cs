
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Enums;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Student : SchoolMember
    {
        [Required]
        [Range(0,999999)]
        public int Founds { get; set; }
        
        [Required]
        public Education ScholarityLevel{ get; set; }
        
        [Required]
        public Tuitor Tuitor { get; set; }

        [Required]
        public IList<CourseGroup> Groups { get; set; }
    }
}
