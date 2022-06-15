
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Course : Entity
    {
        public int Price { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public IList<CourseGroup> CourseGroups { get; set; }
        public IList<TeacherCourseRelation> TeacherCourseRelations { get; set; }
    }
}
