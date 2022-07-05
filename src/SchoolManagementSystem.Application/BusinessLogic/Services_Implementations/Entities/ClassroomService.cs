
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class ClassroomService : ActiveService<Classroom>, IClassroomService
{
    public ClassroomService(IClassroomRepository repository) : base(repository)
    {
        
    }
}   