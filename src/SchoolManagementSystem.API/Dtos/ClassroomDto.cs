
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class ClassroomDto
{
    public string Id { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string Name {get; set;}

    [Required]
    [Range(5, 30)]
    public int Capacity { get; set; }

    public static List<ClassroomDto> GetListClassroomDtos(IQueryable<Classroom> Classrooms)
    {
        var result = new List<ClassroomDto>();

        foreach (var classroom in Classrooms)
        {
            result.Add(
                new ClassroomDto
                {
                    Id = classroom.Id,
                    Name = classroom.Name,
                    Capacity = classroom.Capacity
                }
            );
        }
        
        return result;
    }
    
    public static Classroom GetClassroom(ClassroomDto ClassroomDto, 
        IQueryable<Classroom> classrooms)
    {
        var classroom = classrooms
            .Where(c => c.Name == ClassroomDto.Name)
            .FirstOrDefault();
        
        return classroom;
    }
    
    public static List<Classroom> GetListClassrooms(List<ClassroomDto> ClassroomDtos, 
        IQueryable<Classroom> classrooms)
    {
        var result = new List<Classroom>();

        foreach (var classroomDto in ClassroomDtos)
        {
            var classroom = GetClassroom(classroomDto, classrooms);
            
            if (classroom is not null)
            {
                result.Add(classroom);
            }
        }
        
        return result;
    }
}
