namespace SchoolManagementSystem.Domain.Entities;

public class Teacher : Worker
{
    public IList<CourseGroup> CourseGroups { get; set; }
}