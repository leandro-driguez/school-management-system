
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Worker : SchoolMember
    {
        [Required]
        public IList<CourseGroup> Groups { get; set; }

        [Required] 
        public IList<Resource> ResourcesItProvides { get; set; }

        // [Required]
        // public IList<Position> Positions { get; set; }
    }
}
