using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatmansSecretNumberBook.Models
{
    public abstract class Kontakt
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; } = null!;
    }
}