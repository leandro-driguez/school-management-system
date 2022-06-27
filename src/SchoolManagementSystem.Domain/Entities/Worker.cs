
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities;

public class Worker : SchoolMember
{   
    
    public  IList<Resource> Services { get; set; }

    public  IList<Position> Positions { get; set; }
    
    public  IList<AdditionalService> AdditionalServices { get; set; }
}

public class NonTeacherWorker : Worker
{
    
}

