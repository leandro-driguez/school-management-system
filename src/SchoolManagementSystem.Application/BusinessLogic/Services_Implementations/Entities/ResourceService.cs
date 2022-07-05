
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class ResourceService : ActiveService<Resource>, IResourceService
{
    public ResourceService(IResourceRepository repository) : base(repository)
    {

    }

    public Resource GetResourceById(string id)
    {
        return Query()
            .Where(resource => resource.Id == id)                        
            .Include(resource => resource.AdditionalServices)
            .Include(resource => resource.Providers)
            .FirstOrDefault();
    }
}