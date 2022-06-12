
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Enums;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Student : SchoolMember
    {
        // public Student(string cardId, string name, string lastName, int phoneNumber, 
        //     string address, DateTime dateBecomedMember, Tuitor tuitor, int founds = 0, 
        //     Education scholarityLevel = Education.Secundaria) 
        //     : base(cardId, name, lastName, phoneNumber, address, dateBecomedMember)
        // {
        //     Founds = founds;
        //     ScholarityLevel = scholarityLevel;
        //     Tuitor = tuitor;
        // }

        [Required]
        [Range(0,999999)]
        public int Founds { get; set; }
        
        [Required]
        public Education ScholarityLevel{ get; set; }
        
        [Required]
        public Tuitor Tuitor { get; set; }

        // [Required]
        // public IList<CourseGroup> Groups { get; set; }
    }
}
