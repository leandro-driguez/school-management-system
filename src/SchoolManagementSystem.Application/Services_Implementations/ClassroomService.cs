using SchoolManagementSystem.Application;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class ClassroomService : BaseService<Classroom>, IClassroomService
{
    public ClassroomService(IClassroomRepository repository) : base(repository)
    {
        
    }
}   