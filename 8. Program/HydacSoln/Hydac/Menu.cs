using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hydac
{
    // Controller og UI-lag: al dialog med konsollen ligger her,
    // domænelogikken ligger i Besøg og Medarbejder.
    public class Menu
    {
        private const string Datoformat = "dd-MM-yyyy";
        private const string Tidsformat = "HH:mm";

        private bool erLoggetInd = false;
        private Medarbejder? aktivMedarbejder = null;
        private List<Medarbejder> medarbejderliste = new List<Medarbejder>
        {
            new Medarbejder("Admin", "Admin123")
        };
        private List<Besøg> gæsteliste = new List<Besøg>();
        private Random rnd = new Random();

        public void VisMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("HYDAC Komme-gå-system");
                Console.WriteLine("--------------------");
                if (!erLoggetInd)
                    Console.WriteLine("1. Log ind");
                else
                    Console.WriteLine("1. Log ud");
                Console.WriteLine("2. Opret medarbejder");    // UC01
                Console.WriteLine("3. Opret besøg");          // UC02
                Console.WriteLine("4. Vis medarbejderliste"); // UC03
                Console.WriteLine("5. Vis gæsteliste");       // UC04
                Console.WriteLine("6. Tjek gæst ind");        // UC05
                Console.WriteLine("7. Tjek gæst ud");         // UC06
                Console.WriteLine("--------------------");

                Console.Write(aktivMedarbejder?.Brugernavn + " > ");

                string? svar = Console.ReadLine();
                if (svar == null) // Konsollen er lukket
                    return;
                switch (svar)
                {
                    case "1":
                        if (!erLoggetInd)
                            LogInd();
                        else
                            LogUd();
                        break;
                    case "2":
                        OpretMedarbejder();
                        break;
                    case "3":
                        OpretBesøg();
                        break;
                    case "4":
                        VisMedarbejderliste();
                        break;
                    case "5":
                        VisGæsteliste();
                        break;
                    case "6":
                        TjekInd();
                        break;
                    case "7":
                        TjekUd();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ukendt kommando");
                        VentPåEnter();
                        break;
                }
            }
        }

        private void LogInd()
        {
            Console.Clear();
            Console.WriteLine("Log ind");
            Console.WriteLine("--------------------");
            Console.Write("Indtast brugernavn: ");
            string brugernavn = Console.ReadLine() ?? "";
            Console.Write("Indtast kode: ");
            string kode = Console.ReadLine() ?? "";

            Medarbejder? medarbejder = FindMedarbejder(brugernavn);
            if (medarbejder != null && medarbejder.TjekKode(kode))
            {
                erLoggetInd = true;
                aktivMedarbejder = medarbejder;
                Console.WriteLine("Du er logget ind");
            }
            else
                Console.WriteLine("Forkert brugernavn eller kode");
            VentPåEnter();
        }

        private void LogUd()
        {
            erLoggetInd = false;
            aktivMedarbejder = null;
            Console.WriteLine("Du er logget ud");
            VentPåEnter();
        }

        // UC01 Opret medarbejder
        private void OpretMedarbejder()
        {
            Console.Clear();
            if (!erLoggetInd)
            {
                Console.WriteLine("Du skal være logget ind");
                VentPåEnter();
                return;
            }

            Console.WriteLine("Opret medarbejder");
            Console.WriteLine("--------------------");
            Console.Write("Indtast brugernavn: ");
            string brugernavn = Console.ReadLine() ?? "";
            Console.Write("Indtast kode: ");
            string kode = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(brugernavn) || string.IsNullOrWhiteSpace(kode))
                Console.WriteLine("Brugernavn og kode skal udfyldes");
            else if (FindMedarbejder(brugernavn) != null)
                Console.WriteLine("Brugernavnet findes allerede");
            else
            {
                medarbejderliste.Add(new Medarbejder(brugernavn, kode));
                Console.WriteLine("Medarbejder oprettet");
            }
            VentPåEnter();
        }

        // UC02 Opret besøg
        private void OpretBesøg()
        {
            Console.Clear();
            if (!erLoggetInd)
            {
                Console.WriteLine("Du skal være logget ind");
                VentPåEnter();
                return;
            }

            Console.WriteLine("Opret besøg");
            Console.WriteLine("--------------------");
            Console.Write("Indtast gæstens navn: ");
            string gæstNavn = Console.ReadLine() ?? "";
            Console.Write("Indtast firma: ");
            string firma = Console.ReadLine() ?? "";
            Console.Write("Indtast dato (" + Datoformat + "): ");
            string datoTekst = Console.ReadLine() ?? "";
            Console.Write("Indtast forventet ankomsttid (" + Tidsformat + "): ");
            string ankomsttidTekst = Console.ReadLine() ?? "";
            Console.Write("Indtast forventet afgangstid (" + Tidsformat + "): ");
            string afgangstidTekst = Console.ReadLine() ?? "";
            Console.Write("Indtast lokale: ");
            string lokale = Console.ReadLine() ?? "";
            Console.Write("Indtast ansvarligs brugernavn: ");
            string brugernavn = Console.ReadLine() ?? "";

            if (!DateTime.TryParseExact(datoTekst, Datoformat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dato)
                || !TimeSpan.TryParseExact(ankomsttidTekst, @"hh\:mm", CultureInfo.InvariantCulture, out TimeSpan ankomsttid)
                || !TimeSpan.TryParseExact(afgangstidTekst, @"hh\:mm", CultureInfo.InvariantCulture, out TimeSpan afgangstid))
            {
                Console.WriteLine("Dato eller tid har forkert format. Eksempel: 30-09-2026 og 12:00");
                VentPåEnter();
                return;
            }

            Medarbejder? ansvarlig = FindMedarbejder(brugernavn);
            if (ansvarlig == null)
            {
                Console.WriteLine("Vælg en oprettet medarbejder som ansvarlig");
                VentPåEnter();
                return;
            }

            try
            {
                int indtjekningskode = GenererIndtjekningskode();
                Besøg b = new Besøg(gæstNavn, firma, ansvarlig, dato,
                    dato + ankomsttid, dato + afgangstid, lokale, indtjekningskode);
                gæsteliste.Add(b);
                Console.WriteLine("Besøg oprettet. Indtjekningskode: " + b.Indtjekningskode);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            VentPåEnter();
        }

        // UC03 Vis medarbejderliste
        private void VisMedarbejderliste()
        {
            Console.Clear();
            if (!erLoggetInd)
            {
                Console.WriteLine("Du skal være logget ind");
                VentPåEnter();
                return;
            }

            Console.WriteLine("Medarbejderliste");
            Console.WriteLine("--------------------");
            Console.Write("Søg på brugernavn (tom = alle): ");
            string søgning = Console.ReadLine() ?? "";

            if (medarbejderliste.Count == 0)
            {
                Console.WriteLine("Der er endnu ikke oprettet nogen medarbejdere");
                VentPåEnter();
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"{"Brugernavn",-20}");
            Console.WriteLine(new string('-', 20));
            int antal = 0;
            foreach (Medarbejder m in medarbejderliste)
            {
                if (m.Brugernavn.Contains(søgning, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{m.Brugernavn,-20}");
                    antal++;
                }
            }
            if (antal == 0)
                Console.WriteLine("Ingen medarbejdere fundet");
            VentPåEnter();
        }

        // UC04 Vis gæsteliste
        private void VisGæsteliste()
        {
            Console.Clear();
            if (!erLoggetInd)
            {
                Console.WriteLine("Du skal være logget ind");
                VentPåEnter();
                return;
            }

            Console.WriteLine("Gæsteliste");
            Console.WriteLine("--------------------");
            Console.Write("Indtast dato (" + Datoformat + ", tom = alle): ");
            string datoTekst = Console.ReadLine() ?? "";

            DateTime? valgtDato = null;
            if (datoTekst != "")
            {
                if (!DateTime.TryParseExact(datoTekst, Datoformat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dato))
                {
                    Console.WriteLine("Datoen har forkert format. Eksempel: 30-09-2026");
                    VentPåEnter();
                    return;
                }
                valgtDato = dato;
            }

            Console.WriteLine();
            Console.WriteLine($"{"Indtjekningskode",-18}" +
                $"{"Navn",-18}" +
                $"{"Firma",-14}" +
                $"{"Dato",-12}" +
                $"{"Forv. ankomsttid",-18}" +
                $"{"Forv. afgangstid",-18}" +
                $"{"Lokale",-8}" +
                $"{"Ansvarlig",-14}" +
                $"{"Status",-18}" +
                $"{"Indtjekningstid",-17}" +
                $"{"Udtjekningstid",-16}" +
                $"{"Sikkerhedsfolder",-16}");
            Console.WriteLine(new string('-', 187));

            int antal = 0;
            foreach (Besøg b in gæsteliste)
            {
                if (valgtDato != null && b.Dato != valgtDato)
                    continue;

                Console.WriteLine($"{b.Indtjekningskode,-18}" +
                    $"{b.GæstNavn,-18}" +
                    $"{b.Firma,-14}" +
                    $"{b.Dato.ToString(Datoformat),-12}" +
                    $"{b.ForventetAnkomsttid.ToString(Tidsformat),-18}" +
                    $"{b.ForventetAfgangstid.ToString(Tidsformat),-18}" +
                    $"{b.Lokale,-8}" +
                    $"{b.Ansvarlig.Brugernavn,-14}" +
                    $"{b.Status,-18}" +
                    $"{b.Indtjekningstid?.ToString(Tidsformat),-17}" +
                    $"{b.Udtjekningstid?.ToString(Tidsformat),-16}" +
                    $"{(b.SikkerhedsfolderModtaget ? "Ja" : "Nej"),-16}");
                antal++;
            }
            if (antal == 0)
                Console.WriteLine("Ingen forventede gæster");
            VentPåEnter();
        }

        // UC05 Tjek gæst ind
        private void TjekInd()
        {
            Console.Clear();
            Console.WriteLine("Tjek gæst ind");
            Console.WriteLine("--------------------");
            Console.Write("Indtast indtjekningskode: ");
            int.TryParse(Console.ReadLine(), out int indtjekningskode);

            Besøg? b = FindBesøg(indtjekningskode);
            if (b == null)
                Console.WriteLine("Besøget blev ikke fundet");
            else if (b.Status == Besøg.TjekketInd)
                Console.WriteLine("Gæsten er allerede tjekket ind");
            else if (b.Status == Besøg.TjekketUd)
                Console.WriteLine("Besøget er afsluttet");
            else
            {
                Console.Write("Har gæsten modtaget sikkerhedsfolderen? (ja/nej): ");
                bool sikkerhedsfolderModtaget = (Console.ReadLine() ?? "").Trim().ToLower() == "ja";
                b.TjekInd(sikkerhedsfolderModtaget);
                Console.WriteLine(b.GæstNavn + " er tjekket ind kl. " + b.Indtjekningstid?.ToString(Tidsformat));
                if (!sikkerhedsfolderModtaget)
                    Console.WriteLine("Husk at udlevere sikkerhedsfolderen til gæsten");
            }
            VentPåEnter();
        }

        // UC06 Tjek gæst ud
        private void TjekUd()
        {
            Console.Clear();
            Console.WriteLine("Tjek gæst ud");
            Console.WriteLine("--------------------");
            Console.Write("Indtast indtjekningskode: ");
            int.TryParse(Console.ReadLine(), out int indtjekningskode);

            Besøg? b = FindBesøg(indtjekningskode);
            if (b == null)
                Console.WriteLine("Besøget blev ikke fundet");
            else if (b.Status == Besøg.IkkeTjekketInd)
                Console.WriteLine("Gæsten er ikke tjekket ind");
            else if (b.Status == Besøg.TjekketUd)
                Console.WriteLine("Gæsten er allerede tjekket ud");
            else
            {
                b.TjekUd();
                Console.WriteLine(b.GæstNavn + " er tjekket ud kl. " + b.Udtjekningstid?.ToString(Tidsformat));
            }
            VentPåEnter();
        }

        private Medarbejder? FindMedarbejder(string brugernavn)
        {
            foreach (Medarbejder m in medarbejderliste)
            {
                if (m.Brugernavn == brugernavn)
                    return m;
            }
            return null;
        }

        private Besøg? FindBesøg(int indtjekningskode)
        {
            foreach (Besøg b in gæsteliste)
            {
                if (b.Indtjekningskode == indtjekningskode)
                    return b;
            }
            return null;
        }

        // 8-cifret kode, som ikke allerede er brugt på gæstelisten
        private int GenererIndtjekningskode()
        {
            int indtjekningskode;
            do
            {
                indtjekningskode = rnd.Next(10_000_000, 100_000_000);
            } while (FindBesøg(indtjekningskode) != null);
            return indtjekningskode;
        }

        private void VentPåEnter()
        {
            Console.Write("Enter for at komme tilbage...");
            Console.ReadLine();
        }
    }
}
