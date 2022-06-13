
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities;

public class Worker : SchoolMember
{
    public Worker(string cardId, string name, string lastName, int phoneNumber, string address, 
        DateTime dateBecomedMember) : base(cardId, name, lastName, phoneNumber, address, dateBecomedMember)
    {
    }
    
    public  IList<Resource> Services { get; set; }
}

