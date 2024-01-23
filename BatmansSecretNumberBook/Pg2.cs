using BatmansSecretNumberBook.KontaktKlassen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatmansSecretNumberBook
{
    internal class Pg2
    {
        /*readonly Telefonbuch telefonbuch = new Telefonbuch();
        public void Start()
        {
            bool programmAktiv = true;
            Console.WriteLine("Wilkommen im Telefonbuch!\n\nWas möchten sie machen?");
            while (programmAktiv)
            {
                string input = EingabeHolen("\n\n0: Programm beenden\n1: Alle Kontakte anzeigen.\n2: Einen neuen Kontakt hinzufügen\n3: Einen Kontakt löschen\n4: Einen Kontakt suchen\n\n");

                int inputParsed;
                if (int.TryParse(input, out inputParsed))
                {
                    switch (inputParsed)
                    {
                        case 0:
                            programmAktiv = false;
                            break;
                        case 1:
                            KontakeAnzeigen();
                            break;
                        case 2:
                            KontaktHinzufügen();
                            break;
                        case 3:
                            KontaktLoeschen();
                            break;
                        case 4:
                            KontaktSuchen();
                            break;
                        default:
                            Console.WriteLine("\nDiese zahl ist keiner Aufgabe zugeteit\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nDer input ist keine Zahl\n");
                }
            }
            Console.WriteLine("\nProgramm beendet! Haben sie einen schönen Tag");
        }
        private void KontakeAnzeigen()
        {
            List<Kontakt> kontakte = telefonbuch.GetKontakte();
            if (kontakte.Count == 0)
            {
                Console.WriteLine("\nEs wurder noch kein Kontakt angelegt\n");
            }
            else
            {
                foreach (Kontakt kontakt in kontakte)
                {
                    if (kontakt is GeschäftlichKontakt gKontakt)
                    {
                        Console.WriteLine(gKontakt.ToString());
                    }
                    else if (kontakt is PrivateKontakt pKontakt)
                    {
                        Console.WriteLine(pKontakt.ToString());
                    }
                    else
                    {
                        Console.WriteLine(kontakt.ToString());
                    }
                    Console.WriteLine("\n");
                }
            }
        }
        private void KontaktHinzufügen()
        {
            Console.WriteLine("\nNeuen Kontakt hinzufügen:\n");
            string vorname = string.Empty;
            string nachname = string.Empty;
            string telefonnummer = string.Empty;

            Kontakt kontakt = new Kontakt(vorname, nachname, telefonnummer);
            do
            {
                vorname = EingabeHolen("Vorname");
                nachname = EingabeHolen("Nachname");
                telefonnummer = EingabeHolen("Telefonnummer");
                kontakt = new Kontakt(vorname, nachname, telefonnummer);
            }
            while (!Validate(kontakt));

            int inputParsed;
            string input = EingabeHolen("\nIst dies ein Privater oder Geschäftlicher Kontakt?\n1: Privat\n2: Geschäftlich\n");
            if (int.TryParse(input, out inputParsed))
            {
                switch (inputParsed)
                {
                    case 1:
                        kontakt = AddKontaktPrivate(kontakt);
                        break;
                    case 2:
                        kontakt = AddKontaktGeschäftlich(kontakt);
                        break;
                    default:
                        Console.WriteLine("\nDiese zahl ist keiner Aufgabe zugeteit\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nDer input ist keine Zahl\n");
            }
            telefonbuch.AddKontakt(kontakt);
        }
        private PrivateKontakt AddKontaktPrivate(Kontakt kontakt)
        {
            string input = EingabeHolen("Wer ist dein Lieblings Held?");
            return new PrivateKontakt(kontakt, input);
        }
        private GeschäftlichKontakt AddKontaktGeschäftlich(Kontakt kontakt)
        {
            string input = EingabeHolen("Wie lautet deine Geschäftliche Telefonnummer?");
            GeschäftlichKontakt geschäftlichKontakt = new GeschäftlichKontakt(kontakt, input);
            Validate(geschäftlichKontakt);
            return geschäftlichKontakt;
        }
        private void KontaktLoeschen()
        {
            string input = EingabeHolen("\nDen Kontakt mir der id löschen\n");
            int inputParsed;
            if (int.TryParse(input, out inputParsed))
            {
                Kontakt? gelöschterKontakt = telefonbuch.DeleteKontaktById(inputParsed);
                if (gelöschterKontakt == null)
                {
                    Console.WriteLine($"\nKontakt mit der id {inputParsed} konnte nicht gefunden werden\n");
                }
                else
                {
                    Console.WriteLine($"\nKontakt der gelöscht wurde: {gelöschterKontakt}\n");
                }
            }
            else
            {
                Console.WriteLine("\nDer input ist keine Zahl\n");
            }
        }
        private void KontaktSuchen()
        {
            string input = EingabeHolen("\nKontakt suchen nach Suchbegriff\n");
            List<Kontakt> kontakte = telefonbuch.SearchKontakte(input);
            foreach (Kontakt kontakt in kontakte)
            {
                Console.WriteLine("\n");
                Console.WriteLine(kontakt);
                Console.WriteLine("\n");
            }
        }

        private static string EingabeHolen(string prompt)
        {
            string input;
            do
            {
                Console.Write($"{prompt} -> ");
                input = Console.ReadLine()!;
            } while (string.IsNullOrEmpty(input));
            return input;
        }
        private static bool Validate(Kontakt kontakt)
        {
            ICollection<ValidationResult> results;
            bool isValid = kontakt.Validate(out results);

            if (isValid)
            {
                Console.WriteLine("Die Daten sind gültig!");
                return true;
            }
            else
            {
                Console.WriteLine("Die Daten sind ungültig. Fehler:");
                foreach (var result in results)
                {
                    Console.WriteLine(result.ErrorMessage);
                }
                return false;
            }
        }

        public static void Main()
        {
            new Programm().Start();
        }
        */
    }
}
