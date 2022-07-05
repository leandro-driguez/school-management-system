
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Application.Services_Implementations;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class BasicMeanService : ActiveService<BasicMean>, IBasicMeanService
{
    public BasicMeanService(IBasicMeanRepository repository) : base(repository)
    {
        
    }
}   