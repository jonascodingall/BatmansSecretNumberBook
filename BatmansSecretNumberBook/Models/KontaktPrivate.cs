using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatmansSecretNumberBook.Models
{
    [Table("KontaktPrivate")]
    public class KontaktPrivate : Kontakt
    {
        [Required]
        public string Lieblingsheld { get; set; } = null!;

        [Required]
        public string Telefonnummer { get; set; } = null!;
    }
}