using BatmansSecretNumberBook.Models.ContactModels;
using System.ComponentModel.DataAnnotations;

namespace BatmansSecretNumberBook.Models.PersonModels
{
#nullable disable
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
