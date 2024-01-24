using System.ComponentModel.DataAnnotations;

namespace BatmansSecretNumberBook.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Vorname { get; set; } = null!;

        [Required]
        public string Nachname { get; set; } = null!;

        public List<Kontakt> Kontakte { get; set; } = new List<Kontakt>();
    }
}