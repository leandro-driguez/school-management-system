
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Interfaces;
 namespace SchoolManagementSystem.Domain.Entities;

public class Entity : Identifiable<string>
{
    string _id;
    // [Key]
    public virtual string Id { get; set; } = Guid.NewGuid().ToString(); 
    // public virtual string Id { get{return _id;} set{_id = Guid.NewGuid().ToString(); }}// = Guid.NewGuid().ToString(); 
}