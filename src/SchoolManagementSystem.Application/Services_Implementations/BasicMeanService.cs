
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class BasicMeanService : BaseService<BasicMean>, IBasicMeanService
{
    public BasicMeanService(IBasicMeanRepository repository) : base(repository)
    {
        
    }
}   