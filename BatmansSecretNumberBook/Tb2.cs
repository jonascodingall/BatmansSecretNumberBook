using BatmansSecretNumberBook.KontaktKlassen;

namespace BatmansSecretNumberBook
{
    /*
    public class Tb2
    {
        private List<Kontakt> _kontakte;
        public List<Kontakt> Kontake
        {
            get
            {
                _kontakte = _kontakte.OrderBy(k => k.Id).ToList();
                return _kontakte;
            }
        }

        public Tb2()
        {
            _kontakte = new List<Kontakt>();
        }

        //fügt einen neuen Kontakt hinzu
        public void AddKontakt(Kontakt k)
        {
            _kontakte = _kontakte.OrderBy(k => k.Id).ToList();

            int newId = 1;

            foreach (Kontakt kontakt in _kontakte)
            {
                if (kontakt.Id == newId)
                {
                    newId++;
                }
                else
                {
                    break;
                }
            }
            _kontakte.Add(new Kontakt(newId, k.Vorname, k.Nachname, k.Telefonnummer));
        }

        //Nimmt einen Kontakt als input und löscht ihn, Falls dieser existiert er zurückgegeben, fals nicht wird null zurückgegeben;
        public Kontakt? DeletKontakt(Kontakt kontakt)
        {
            if (_kontakte.Contains(kontakt))
            {
                _kontakte.Remove(kontakt);
                return kontakt;
            }
            else
            {
                return null;
            }
        }

        //Nimmt einen Kontakt als input und löscht ihn, Falls dieser existiert er zurückgegeben, fals nicht wird null zurückgegeben;
        public Kontakt? DeleteKontaktById(int id)
        {
            Kontakt? gelöschterKontakt = null;
            foreach (Kontakt kontakt in _kontakte)
            {
                if (kontakt.Id == id)
                {
                    gelöschterKontakt = kontakt;
                    break;
                }
            }
            if (gelöschterKontakt != null)
            {
                _kontakte.Remove(gelöschterKontakt);
            }
            return gelöschterKontakt;
        }

        //Gibt eine Liste mit allen Kontakten zurück
        public List<Kontakt> GetKontakte()
        {
            return _kontakte;
        }

        //Sucht Kontakt nach suchbegriff und gibt eine Liste mit Kontakten zurück, bei dem  eins der Parameter dem scuhbegriff endspricht
        public List<Kontakt> SearchKontakte(string suchbegriff)
        {
            List<Kontakt> gefundeneKontakte = new List<Kontakt>();
            foreach (var kontakt in _kontakte)
            {
                if (kontakt.Id.ToString() == suchbegriff
                    || kontakt.Vorname == suchbegriff
                    || kontakt.Nachname == suchbegriff
                    || kontakt.Telefonnummer == suchbegriff)
                {
                    gefundeneKontakte.Add(kontakt);
                }
            }
            return gefundeneKontakte;
        }
    }
    */
}
