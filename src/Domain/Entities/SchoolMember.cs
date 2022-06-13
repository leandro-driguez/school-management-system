
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class SchoolMember : Entity
    {
        public SchoolMember(string cardId, string name, string lastName, 
            int phoneNumber, string address, DateTime dateBecomedMember)
        {
            CardId = cardId;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            DateBecomedMember = dateBecomedMember;
            Id = "";

            UpdateKey();
        }

        [Required]
        public string CardId { get; set; }

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

        public void UpdateKey(){
            string id = CardId;
              
            while (id.Length < 32){
                id = "0" + id;
            }

            Id = new Guid(id).ToString();
        }
    }
}
