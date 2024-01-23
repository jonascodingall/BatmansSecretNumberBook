using System.ComponentModel.DataAnnotations;


namespace BatmansSecretNumberBook.Models
{
    public abstract class Kontakt
    {
        [Key]
        public int KontaktId { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Nachname { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Telefonnummer { get; set; }
    }
}