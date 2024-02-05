using System.ComponentModel.DataAnnotations;

namespace BatmansSecretNumberBook.Models.ContactModels
{
#nullable disable
    public class ContactPrivate : Contact
    {
        [Required]
        public string FavouriteHero {  get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
