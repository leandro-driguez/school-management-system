
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations.Entities;

public class ClassroomService : BaseService<Classroom>, IClassroomService
{
    public ClassroomService(IClassroomRepository repository) : base(repository)
    {
        
    }
}   