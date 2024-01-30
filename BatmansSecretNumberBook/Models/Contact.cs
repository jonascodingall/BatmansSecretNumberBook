using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatmansSecretNumberBook.Models
{
#nullable disable
    public abstract class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; }
    }
}
