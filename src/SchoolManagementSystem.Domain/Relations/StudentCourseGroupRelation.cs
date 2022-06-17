
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Relations
{
    public class StudentCourseGroupRelation
    {
        #region Student Key
        public string StudentId { get; set; }
        #endregion
        public Student Student { get; set; }

        #region  CourseGroup Keys
        public string CourseGroupId { get; set; }
        public string CourseGroupCourseId { get; set; }
        #endregion
        public CourseGroup CourseGroup { get; set; }
        
        public DateTime StartDate{ get; set; }
        
        public DateTime EndDate{ get; set; }
    }
}
