using BatmansSecretNumberBook.Data;
using BatmansSecretNumberBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BatmansSecretNumberBook
{
    public class Telefonbuch
    {
        private readonly BSNBContext context;

        public Telefonbuch()
        {
            context = new BSNBContext();
        }

        public List<Kontakt> GetKontakte()
        {
            var kontakte = new List<Kontakt>();

            kontakte.AddRange(context.KontakteBuisness);
            kontakte.AddRange(context.KontaktePrivate);

            return kontakte;
        }

        public void AddKontaktPrivate(string vorname, string nachname, string telefonnummer, string lieblingsheld)
        {
            var neuerKontakt = new KontaktPrivate
            {
                Vorname = vorname,
                Nachname = nachname,
                Telefonnummer = telefonnummer,
                LieblingsHeld = lieblingsheld,
            };

            if (!neuerKontakt.Validate(out var validationResults))
            {
                var errorMessages = validationResults.Select(result => result.ErrorMessage);
                throw new InvalidOperationException($"Kontakt konnte nicht hinzugefügt werden. Fehler: {string.Join("; ", errorMessages)}");
            }

            context.KontaktePrivate.Add(neuerKontakt);
            context.SaveChanges();
        }

        public void AddKontaktBuisness(string vorname, string nachname, string telefonnummer, string telefonnumerbuisness)
        {
            var neuerKontakt = new KontaktBuisness
            {
                Vorname = vorname,
                Nachname = nachname,
                Telefonnummer = telefonnummer,
                TelefonnummerBuisness = telefonnumerbuisness,
            };

            if (!neuerKontakt.Validate(out var validationResults))
            {
                var errorMessages = validationResults.Select(result => result.ErrorMessage);
                throw new InvalidOperationException($"Kontakt konnte nicht hinzugefügt werden. Fehler: {string.Join("; ", errorMessages)}");
            }

            context.KontakteBuisness.Add(neuerKontakt);
            context.SaveChanges();
        }


        private void RemoveKontakt<T>(DbSet<T> kontakteSet, string suchbegriff) where T : Kontakt
        {
            var kontakte = kontakteSet.ToList();

            var kontaktToRemove = kontakte.FirstOrDefault(kontakt => kontakt.ToString().ToLower().Contains(suchbegriff.ToLower()));

            if (kontaktToRemove == null)
            {
                throw new ArgumentNullException(nameof(kontaktToRemove), "Kontakt nicht gefunden");
            }

            kontakteSet.Remove(kontaktToRemove);
            context.SaveChanges();
        }


        public void RemoveKontaktPrivate(string suchbegriff)
        {
            RemoveKontakt(context.KontaktePrivate, suchbegriff);
        }

        public void RemoveKontaktBuisness(string suchbegriff)
        {
            RemoveKontakt(context.KontakteBuisness, suchbegriff);
        }

        public List<Kontakt> SearchKontakt(string suchbegriff)
        {
            var kontakteBuisness = context.KontakteBuisness.ToList();
            var kontaktePrivate = context.KontaktePrivate.ToList();

            var kontakte = new List<Kontakt>();

            kontakte.AddRange(kontakteBuisness.Where(kontakt => kontakt.ToString().ToLower().Contains(suchbegriff.ToLower())));
            kontakte.AddRange(kontaktePrivate.Where(kontakt => kontakt.ToString().ToLower().Contains(suchbegriff.ToLower())));

            return kontakte;
        }

    }
}
