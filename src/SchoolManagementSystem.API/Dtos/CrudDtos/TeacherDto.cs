
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Dtos;

public class TeacherDto : IDto
{
    public string Id { get; set; }
}
