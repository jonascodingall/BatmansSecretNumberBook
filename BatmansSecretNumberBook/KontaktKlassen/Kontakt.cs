using System.ComponentModel.DataAnnotations;

namespace BatmansSecretNumberBook.KontaktKlassen
{
    public abstract class Kontakt
    {
        private string _vorname;
        public string Vorname
        {
            get { return _vorname; }
            set { _vorname = value; }
        }

        private string _nachname;
        public string Nachname
        {
            get { return _nachname; }
            set { _nachname = value; }
        }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Telefonnummer { get; set; }

        public Kontakt(string vorname, string nachname, string telefonnummer)
        {
            _vorname = vorname;
            _nachname = nachname;
            Telefonnummer = telefonnummer;
        }

        new public virtual string ToString()
        {
            return $"Vorname: {_vorname}\nNachname: {_nachname}\nTelefonnummer: {Telefonnummer}\n";
        }

        public bool Validate(out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(this, context, results, true);
        }

    }
}
