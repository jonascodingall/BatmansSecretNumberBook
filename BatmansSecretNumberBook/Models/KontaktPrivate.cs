using System.ComponentModel.DataAnnotations;

namespace BatmansSecretNumberBook.Models
{
    public class KontaktPrivate : Kontakt
    {
        public string LieblingsHeld { get; set; } = null!;
    }
}