using System;
using System.Linq;
using BatmansSecretNumberBook;
using BatmansSecretNumberBook.Models;

class Program
{
    private readonly Telefonbuch telefonbuch = new Telefonbuch();

    public void Start()
    {
        Print("Willkommen zu Batmans Geheimem Telefonbuch!");

        bool programActive = true;

        while (programActive)
        {
            Print("\n0: Programm beenden\n1: Kontakte anzeigen\n2: Kontakt hinzufügen\n3: Kontakt löschen\n4: Kontakt suchen");

            string input = GetValidInput("Bitte wählen Sie eine Option:");

            int inputParsed;
            if (int.TryParse(input, out inputParsed))
            {
                switch (inputParsed)
                {
                    case 0:
                        programActive = false;
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
                        Print("Ungültige Option. Bitte geben Sie eine gültige Nummer ein.");
                        break;
                }
            }
            else
            {
                Print("Ungültige Eingabe. Bitte geben Sie eine Zahl ein.");
            }
        }
    }

    private void ViewKontakt()
    {
        var kontakte = telefonbuch.GetKontakte();

        if (kontakte.Count == 0)
        {
            Print("Es wurden noch keine Kontakte erstellt.");
        }
        else
        {
            foreach (var kontakt in kontakte)
            {
                Print(kontakt.ToString());
            }
        }
    }

    private void AddKontakt()
    {
        Print("Was für einen Kontakt möchten Sie erstellen?\n1: Geschäftlich\n2: Privat");

        int[] kontaktArten = { 1, 2 };
        int kontaktArtParsed = GetValidInputAsInt("Bitte wählen Sie eine Kontaktart:", kontaktArten);

        while (true)
        {
            string vorname = Input("Vorname:");
            string nachname = Input("Nachname:");
            string telefonnummer = Input("Telefonnummer:");

            try
            {
                if (kontaktArtParsed == 1)
                {
                    string telefonnummerBuisness = Input("Geschäftliche Telefonnummer:");
                    try
                    {
                        telefonbuch.AddKontaktBuisness(vorname, nachname, telefonnummer, telefonnummerBuisness);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (kontaktArtParsed == 2)
                {
                    string liebingsHeld = Input("Lieblingsheld:");
                    try
                    {
                    telefonbuch.AddKontaktPrivate(vorname, nachname, telefonnummer, liebingsHeld);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Print("Kontakt erfolgreich hinzugefügt.");
                break;
            }
            catch (InvalidOperationException e)
            {
                Print(e.Message);
            }
        }
    }

    private void DeleteKontakt()
    {
        string input = Input("Welchen Kontakt möchten Sie löschen?");
        try
        {
            var kontakte = telefonbuch.GetKontakte();
            var kontaktToRemove = kontakte.FirstOrDefault(kontakt => kontakt.ToString().ToLower().Contains(input.ToLower()));

            if (kontaktToRemove == null)
            {
                Print("Kontakt nicht gefunden.");
                return;
            }

            if (kontaktToRemove is KontaktBuisness)
            {
                telefonbuch.RemoveKontaktBuisness(input);
            }
            else if (kontaktToRemove is KontaktPrivate)
            {
                telefonbuch.RemoveKontaktPrivate(input);
            }

            Print("Kontakt erfolgreich gelöscht.");
        }
        catch (InvalidOperationException e)
        {
            Print(e.Message);
        }
    }


    private void SearchKontakt()
    {
        string input = Input("Nach welchem Kontakt möchten Sie suchen?");
        try
        {
            var foundKontakte = telefonbuch.SearchKontakt(input);

            if (foundKontakte.Count == 0)
            {
                Print("Keine Kontakte gefunden.");
            }
            else
            {
                foreach (var kontakt in foundKontakte)
                {
                    Print(kontakt.ToString());
                }
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

    private static string Input(object prompt)
    {
        string input;
        do
        {
            Console.Write($"{prompt} ");
            input = Console.ReadLine()!;
        } while (string.IsNullOrWhiteSpace(input));
        Console.WriteLine();
        return input.Trim();
    }

    private string GetValidInput(string prompt)
    {
        string input;
        do
        {
            input = Input(prompt);
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }

    private int GetValidInputAsInt(string prompt, int[] validOptions)
    {
        while (true)
        {
            string input = GetValidInput(prompt);

            if (int.TryParse(input, out int inputParsed) && validOptions.Contains(inputParsed))
            {
                return inputParsed;
            }

            Print("Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein.");
        }
    }

    public static void Main()
    {
        new Program().Start();
    }
}
