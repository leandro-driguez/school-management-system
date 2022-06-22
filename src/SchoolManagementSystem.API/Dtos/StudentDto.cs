
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;
public enum Education
{
    Primaria,
    Secundaria,
    EscuelaOficios,
    TecnicoMedio,
    Preuniversitario,
    Universidad,
    Posgrado
}

public class StudentDto : IDto
{
    public string Id { get; set; }

    [Required]
    public Tuitor Tuitor { get; set; }
    [Required]
    public int Founds { get; set; }
    [Required]
    public Education ScholarityLevel { get; set; }

}
