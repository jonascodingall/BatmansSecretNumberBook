using System.ComponentModel.DataAnnotations;

namespace BatmansSecretNumberBook.Models
{
#nullable disable
    public class ContactBusiness : Contact
    {
        [Required]
        public string PhoneNumberBusiness { get; set; }
    }
}
