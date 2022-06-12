
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class SchoolMember : Entity
    {
        public SchoolMember(string cardId, string name, string lastName, int phoneNumber, string address, DateTime dateBecomedMember) 
            : base(new Guid(cardId))
        {
            CardId = cardId;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            DateBecomedMember = dateBecomedMember;
        }

        [Required]
        public string CardId 
        { 
            get => CardId;
            
            // is value a valid input?
            set => Id = new Guid(value);
        }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        
        [Required]
        public int PhoneNumber{ get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Date Becomed Member")]
        public DateTime DateBecomedMember { get; set; }
    }
}
