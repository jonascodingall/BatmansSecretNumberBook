using BatmansSecretNumberBook.KontaktKlassen;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace BatmansSecretNumberBook
{
    class Telefonbuch
    {
        LinkedListDouble<Kontakt> Kontakte { get; }
        public Telefonbuch()
        {
            Kontakte = new LinkedListDouble<Kontakt>();
        }

        public void AddKontaktBuisness(string vorname, string nachname, string telefonnummer, string telefonnummerBuisness)
        {
            var kontakt = new KontaktBuisness(vorname, nachname, telefonnummer, telefonnummerBuisness);
            if (kontakt.Validate(out ICollection<ValidationResult> results))
            {
                Kontakte.AddToBack(kontakt);
            }
            else
            {
                var exeptionString = "";
                foreach (var result in results)
                {
                    exeptionString += result.ErrorMessage;
                }
                throw new InvalidOperationException($"Konnte nicht Validiert werden: {exeptionString}");
            }
        }
        public void AddKontaktPrivate(string vorname, string nachname, string telefonnummer, string lieblingsheld)
        {
            var kontakt = new KontaktPrivate(vorname, nachname, telefonnummer, lieblingsheld);
            if (kontakt.Validate(out ICollection<ValidationResult> results))
            {
                Kontakte.AddToBack(kontakt);
            }
            else
            {
                var exeptionString = "";
                foreach (var result in results)
                {
                    exeptionString += result.ErrorMessage;
                }
                throw new InvalidOperationException($"Konnte nicht Validiert werden: {exeptionString}");
            }
        }
        public void DeleteKontakt(string suchbegriff)
        {
            var foundKontakt = FindKontaktByCriteria(suchbegriff);
            Kontakte.RemoveWhere(kontakt => kontakt == foundKontakt);
        }
        public LinkedListDouble<Kontakt> SearchKontakt(string suchbegriff)
        {
            return FindKontakteByCriteria(suchbegriff);
        }
        private Kontakt FindKontaktByCriteria(string suchbegriff)
        {
            var foundKontakt = Kontakte.FirstOrDefault(kontakt =>
                kontakt.Vorname == suchbegriff ||
                kontakt.Nachname == suchbegriff ||
                kontakt.Telefonnummer == suchbegriff ||
                (kontakt is KontaktBuisness kontaktBuisness && kontaktBuisness.TelefonnummerBuisness == suchbegriff) ||
                (kontakt is KontaktPrivate kontaktPrivate && kontaktPrivate.LieblingsHeld == suchbegriff)
            );

            if (foundKontakt != null)
            {
                return foundKontakt;
            }
            else
            {
                throw new InvalidOperationException($"Kontakt nach dem Begriff {suchbegriff} nicht gefunden werden");
            }
        }

        private LinkedListDouble<Kontakt> FindKontakteByCriteria(string suchbegriff)
        {
            var foundKontakte = new LinkedListDouble<Kontakt>();

            foreach (var kontakt in Kontakte)
            {
                if (kontakt.Vorname == suchbegriff ||
                    kontakt.Nachname == suchbegriff ||
                    kontakt.Telefonnummer == suchbegriff ||
                    (kontakt is KontaktBuisness kontaktBuisness && kontaktBuisness.TelefonnummerBuisness == suchbegriff) ||
                    (kontakt is KontaktPrivate kontaktPrivate && kontaktPrivate.LieblingsHeld == suchbegriff))
                {
                    foundKontakte.AddToBack(kontakt);
                }
            }

            if (foundKontakte.Count > 0)
            {
                return foundKontakte;
            }
            else
            {
                throw new InvalidOperationException($"Kein Kontakt nach dem Begriff {suchbegriff} gefunden");
            }
        }

        public LinkedListDouble<Kontakt> getKontakte()
        {
            return Kontakte;
        }
    }
}