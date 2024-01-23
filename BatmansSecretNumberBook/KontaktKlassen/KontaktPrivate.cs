using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatmansSecretNumberBook.KontaktKlassen
{
    public class KontaktPrivate : Kontakt
    {
        public string LieblingsHeld { get; set; }
        public KontaktPrivate(string vorname, string nachname, string telefonnummer, string lieblingsheld) : base(vorname, nachname, telefonnummer)
        {
            LieblingsHeld = lieblingsheld;
        }
        public override string ToString()
        {
            return $"{base.ToString()}Lieblings Held: {LieblingsHeld}";
        }
    }
}
