using System.ComponentModel.DataAnnotations;

namespace Contacts_Application.Models
{
    public class Contacts
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Email { get; set; }

        [MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string Phone { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}