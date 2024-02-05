using System.ComponentModel.DataAnnotations;

namespace BatmansSecretNumberBook.Models.ContactModels
{
#nullable disable
    public class ContactBusiness : Contact
    {
        [Phone]
        public string PhoneNumberBusiness { get; set; }
    }
}
