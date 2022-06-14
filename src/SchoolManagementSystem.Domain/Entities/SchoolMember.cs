
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class SchoolMember : Entity
    {
        private protected string _id;

        // [Required]
        public override string Id {
            get => _id;
            
            set{
                string CardId = value;
              
                while (CardId.Length < 32){
                    CardId = "0" + CardId;
                }

                _id = new Guid(CardId).ToString();
            }
        }

        // [Required]
        // [MaxLength(20)]
        public string Name { get; set; }
        
        // [Required]
        // [MaxLength(30)]
        public string LastName { get; set; }
        
        // [Required]
        public int PhoneNumber{ get; set; }
        
        // [Required]
        // [MaxLength(50)]
        public string Address { get; set; }
        
        // [Required]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        //                ApplyFormatInEditMode = true)]
        // [Display(Name = "Date Becomed Member")]
        public DateTime DateBecomedMember { get; set; }
    }
}
