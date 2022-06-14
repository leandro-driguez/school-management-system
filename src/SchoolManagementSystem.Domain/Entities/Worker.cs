
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities;

public class Worker : SchoolMember
{   
    public  IList<Resource> Services { get; set; }
}

