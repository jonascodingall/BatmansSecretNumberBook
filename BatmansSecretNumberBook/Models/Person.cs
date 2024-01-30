using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BatmansSecretNumberBook.Models
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
