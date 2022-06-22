using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Domain.Services;

public interface IResourceService : IService<Resource>
{
    // Selecciona un recurso con cierto id
    // y toma toda su informaci�n
    // Resource GetResourceById(string id);
}