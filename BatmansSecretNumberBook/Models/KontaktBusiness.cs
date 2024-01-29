using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatmansSecretNumberBook.Models
{
    public class KontaktBusiness : Kontakt
    {
        [Required]
        public string Geschäftsnummer { get; set; } = null!;
    }
}