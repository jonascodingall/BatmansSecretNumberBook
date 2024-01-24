using System.ComponentModel.DataAnnotations;


namespace BatmansSecretNumberBook.Models
{
    public abstract class Kontakt
    {
        [Key]
        public int KontaktId { get; set; }

        [Required]
        public string Vorname { get; set; } = null!;

        [Required]
        public string Nachname { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Telefonnummer { get; set; } = null!;

        public virtual bool Validate(out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results, true);
            return isValid;
        }
        public override string ToString()
        {
            return $"{KontaktId} {Vorname} {Nachname} {Telefonnummer}";
        }
    }
}