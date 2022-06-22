
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services.Entities;

namespace SchoolManagementSystem.Application.Services_Implementations.Entities;

public class PositionService : BaseService<Position>, IPositionService
{
    public PositionService(IPositionRepository repository) : base(repository)
    {

    }
}