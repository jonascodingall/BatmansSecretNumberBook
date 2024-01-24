using System.ComponentModel.DataAnnotations;


namespace BatmansSecretNumberBook.Models
{
    public class KontaktBuisness : Kontakt
    {
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string TelefonnummerBuisness { get; set; } = null!;

        public override bool Validate(out ICollection<ValidationResult> results)
        {
            var baseValidationResult = base.Validate(out results);
            if (!string.IsNullOrEmpty(TelefonnummerBuisness) && TelefonnummerBuisness.Length < 10)
            {
                results.Add(new ValidationResult("TelefonnummerBuisness muss mindestens 10 Zeichen lang sein."));
                baseValidationResult = false;
            }

            return baseValidationResult;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {TelefonnummerBuisness}";
        }
    }
}