using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Domain.Services;

public interface IResourceService : IService<Resource>
{
    // Selecciona un recurso con cierto id
    // y toma toda su información
    Resource GetResourceById(string id);
}