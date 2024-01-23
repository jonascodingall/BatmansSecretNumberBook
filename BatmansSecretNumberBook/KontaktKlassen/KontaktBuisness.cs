using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatmansSecretNumberBook.KontaktKlassen
{
    public class KontaktBuisness : Kontakt
    {
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string TelefonnummerBuisness { get; set; }

        public KontaktBuisness(string vorname, string nachname, string telefonnummer, string telefonnummerBuisness) : base(vorname, nachname, telefonnummer)
        {
            TelefonnummerBuisness = telefonnummerBuisness;
        }

        new public bool Validate(out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(this, context, results, true);
        }
        public override string ToString()
        {
            return $"{base.ToString()}Geschäftliche Nummer: {TelefonnummerBuisness}";
        }
    }
}
