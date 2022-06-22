
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class TuitorService : BaseService<Tuitor>, ITuitorService
{
    public TuitorService(ITuitorRepository repository) : base(repository)
    {

    }

    public Tuitor GetTuitorById(string id)
    {
        return Query()
            .Where(tuitor => tuitor.Id == id)                        
            .Include(tuitor => tuitor.Students)            
            .FirstOrDefault();
    }
}