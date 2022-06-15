
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Relations
{
    public class TeacherCourseGroupRelation
    {
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string CourseGroupId { get; set; }
        public string CourseGroupCourseId { get; set; }
        public CourseGroup CourseGroup { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate{ get; set; }
    }
}
