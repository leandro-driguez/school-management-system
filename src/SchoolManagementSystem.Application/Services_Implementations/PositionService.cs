
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class PositionService : BaseService<Position>, IPositionService
{
    public PositionService(IPositionRepository repository) : base(repository)
    {

    }
}