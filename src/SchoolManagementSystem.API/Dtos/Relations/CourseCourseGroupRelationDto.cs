
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolManagementSystem.API.Dtos;

public class CourseCourseGroupRelationDto
{
        [JsonPropertyName("key")]
        public string CouresANDCourseGroupId{get;set;}  
        public string Id { get; set; }
        [Required]
        public string TeacherName { get; set; }
        public string CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Capacity { get; set; }
        public int TotalStudents{get; set;}
        [Required]
        public DateTime StartDate { get; set; } //= DateTime.Now();
        [Required]
        public DateTime EndDate { get; set; }
}
