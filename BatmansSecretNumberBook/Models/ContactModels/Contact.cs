using BatmansSecretNumberBook.Models.PersonModels;
using System.ComponentModel.DataAnnotations;

namespace BatmansSecretNumberBook.Models.ContactModels
{
#nullable disable
    public abstract class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
