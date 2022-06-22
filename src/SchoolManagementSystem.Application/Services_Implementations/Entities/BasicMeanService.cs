
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;
using SchoolManagementSystem.Application.Services_Implementations.Entities;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services.Entities;

namespace SchoolManagementSystem.Application.Services_Implementations.Entities;

public class BasicMeanService : BaseService<BasicMean>, IBasicMeanService
{
    public BasicMeanService(IBasicMeanRepository repository) : base(repository)
    {
        
    }
}   