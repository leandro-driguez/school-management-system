
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Relations
{
    public class StudentCourseGroupRelation
    {
        public string StudentId { get; set; }
        public Student Student { get; set; }
        
        public string CourseGroupId { get; set; }
        public string CourseGroupCourseId { get; set; }
        public CourseGroup CourseGroup { get; set; }
        
        public DateTime StartDate{ get; set; }
        
        public DateTime EndDate{ get; set; }
    }
}
