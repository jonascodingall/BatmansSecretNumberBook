using System.ComponentModel.DataAnnotations;


namespace BatmansSecretNumberBook.Models
{
    public class KontaktBuisness : Kontakt
    {
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string TelefonnummerBuisness { get; set; }
    }
}