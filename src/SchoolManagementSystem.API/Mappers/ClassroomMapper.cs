using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Mappers;

public class ClassroomMapper : IMapper<ClassroomDto, Classroom>, IMapper<Classroom, ClassroomDto>
{
    Func<ClassroomDto, Classroom> IMapper<ClassroomDto, Classroom>.Mapper()
    {
        return delegate(ClassroomDto dto)
        {
            return new Classroom
            {
                Id = dto.Id,
                Name = dto.Name,
                Capacity = dto.Capacity
            };
        };
    }

    Func<Classroom, ClassroomDto> IMapper<Classroom, ClassroomDto>.Mapper()
    {
        return delegate(Classroom classroom)
        {
            return new ClassroomDto
            {
                Id = classroom.Id,
                Name = classroom.Name,
                Capacity = classroom.Capacity
            };
        };
    }
}