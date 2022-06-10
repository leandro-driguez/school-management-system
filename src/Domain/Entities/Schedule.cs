using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,   
        Sunday
    }
    public class Schedule : Entity
    {
        public int Duration { get; set; }
        public DateTime StartDate{ get; set; }
        public DayOfWeek DayOfWeek { get; set; }    
    }
}
