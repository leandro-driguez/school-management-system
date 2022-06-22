
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;
// public enum Education
// {
//     Primaria,
//     Secundaria,
//     EscuelaOficios,
//     TecnicoMedio,
//     Preuniversitario,
//     Universidad,
//     Posgrado
// }

public class StudentDto : SchoolMemberDto
{

    [Required]
    public string TuitorName { get; set; }
    [Required]
    public int Founds { get; set; }
    [Required]
    public string ScholarityLevel { get; set; }

}
