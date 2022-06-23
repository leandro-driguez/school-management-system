
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Domain.Entities
{ 
    public class CourseGroup : Entity
    {
        public string CourseId { get; set; }
        public Course Course { get; set; }
        // public string Name {get; set;}
        public Teacher Teacher{ get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; } //= DateTime.Now();
        public DateTime EndDate { get; set; }
        public IList<StudentCourseGroupRelation> StudentCourseGroupRelations { get; set; }
        public IList<TeacherCourseGroupRelation> TeacherCourseGroupRelations { get; set; }
    }
}
