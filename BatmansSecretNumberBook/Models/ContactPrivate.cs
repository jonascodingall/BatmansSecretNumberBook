using System.ComponentModel.DataAnnotations;

namespace BatmansSecretNumberBook.Models
{
#nullable disable
    public class ContactPrivate : Contact
    {
        [Required]
        public string FavouriteHero { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
