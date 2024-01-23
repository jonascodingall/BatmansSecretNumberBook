using BatmansSecretNumberBook;
using BatmansSecretNumberBook.KontaktKlassen;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

class Programm
{
    private readonly Telefonbuch telefonbuch = new Telefonbuch();
    public void Start()
    {
        Print("Wilkommen zu Batmans Geheimen Telefonbuch!");

        Print("Das hier sind ihre opotionen:");


        bool programmActiv = true;

        while (programmActiv)
        {
            Print("\n0: Program beenden\n1: Kontakte anzeigen\n2: Kontakt hinzufügen\n3: Kontakt Löschen\n4: Kontakt suchen\n");

            string input = string.Empty;
            int inputParsed;

            input = Input();
            while (!int.TryParse(input, out inputParsed))
            {
                input = Input("Nur Zahlen im Zahlenbereich eines Integers sind Erlaubt");
            } 
            
            switch (inputParsed)
            {
                case 0:
                    programmActiv = false;
                    break;
                case 1:
                    ViewKontakt();
                    break;
                case 2:
                    AddKontakt();
                    break;
                case 3:
                    DeleteKontakt();
                    break;
                case 4:
                    SearchKontakt();
                    break;
                default:
                    Console.WriteLine("Die Nummer macht nichts");
                    break;
            }
        }
    }

    private void ViewKontakt()
    {
        var kontakte = telefonbuch.getKontakte();
        if (kontakte.Count == 0)
        {
            Print("Es wurden noch keine Kontakte erstellt");
        }
        foreach (var kontakt in kontakte)
        {
            Print(kontakt.ToString());
        }
    }
    private void AddKontakt()
    {
        Print("Was für einen Kontakt wollen sie erstellen?\n1: Geschäftlich\n2: Privat");

        int[] kontaktArten = new int[] { 1, 2 };
        int kontaktArtParsed;
        string kontaktArt = Input();

        while (!int.TryParse(kontaktArt, out kontaktArtParsed) || !kontaktArten.Contains(kontaktArtParsed))
        {
            Print("Ungültige Eingabe. Nur Zahlen im Zahlenbereich eines Integers sind erlaubt. ");

            if (!int.TryParse(kontaktArt, out kontaktArtParsed))
            {
                Print("Bitte geben Sie eine gültige Zahl ein. ");
            }
            else if (!kontaktArten.Contains(kontaktArtParsed))
            {
                Print($"Es ist nur der Zahlenbereich von {string.Join(", ", kontaktArten)} erlaubt. ");
            }

            kontaktArt = Input("Versuchen Sie es erneut: ");
        }

        bool isValid = false;
        while (!isValid)
        {
            string vorname = Input("Vorname");
            string nachname = Input("Nachname");
            string telefonnummer = Input("Telefonnummer");

            switch (kontaktArtParsed)
            {
                case 1:
                    string telefonnummerBuisness = Input("Geschäftliche Telefonnummer");
                    try
                    {
                        telefonbuch.AddKontaktBuisness(vorname, nachname, telefonnummer, telefonnummerBuisness);
                        isValid = true;
                    }
                    catch (InvalidOperationException e)
                    {
                        Print(e.Message);
                        isValid = false;
                    }

                    break;
                case 2:
                    string liebingsHeld = Input("Lieblings Held");
                    try
                    {
                        telefonbuch.AddKontaktPrivate(vorname, nachname, telefonnummer, liebingsHeld);
                        isValid = true;
                    }
                    catch (InvalidOperationException e)
                    {
                        Print(e.Message);
                        isValid = false;
                    }
                    break;
            }
        }
    }
    private void DeleteKontakt()
    {
        string input = Input("Welchen Kontakt möchten sie Löschen?");
        try
        {
            telefonbuch.DeleteKontakt(input);
        }
        catch(InvalidOperationException e)
        {
            Print(e.Message);
        }
    }
    private void SearchKontakt()
    {
        string input = Input("Wonach möchten sie suchen?");
        try
        {
            var foundKontakte = telefonbuch.SearchKontakt(input);
            foreach (var kontakt in foundKontakte)
            {
                Print(kontakt.ToString());
            }
        }
        catch (InvalidOperationException e)
        {
            Print(e.Message);
        }
    }

    private static void Print(object prompt)
    {
        Console.WriteLine($"{prompt}\n");
    }
    private static string Input()
    {
        string input;
        do
        {
            Console.Write(" -> ");
            input = Console.ReadLine()!;
        } while (string.IsNullOrEmpty(input));
        Console.WriteLine("\n");
        return input;
    }
    private static string Input(object prompt)
    {
        string input;
        do
        {
            Console.Write($"{prompt}\n -> ");
            input = Console.ReadLine()!;
        } while (string.IsNullOrEmpty(input));
        Console.WriteLine("\n");
        return input;
    }

    public static void Main()
    {
        new Programm().Start();
    }
}