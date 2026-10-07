using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hydac
{
<<<<<<< HEAD
    public class Menu
    {
        public bool erLoggetind;
        public string aktivMedarbejder = "";

        public List<Medarbejder> MedarbejderListe = new List<Medarbejder>
        {
            new Medarbejder("Admin", "Admin123")
        };

        public List<Besøg> BesøgListe = new List<Besøg>();

        public void MenuShow()
=======
    // Controller og UI-lag: al dialog med konsollen ligger her,
    // domænelogikken ligger i Besøg og Medarbejder.
    public static class Menu
    {
        private const string Datoformat = "dd-MM-yyyy";
        private const string Tidsformat = "HH:mm";

        private static bool erLoggetInd = false;
        private static Medarbejder? aktivMedarbejder = null;
        private static List<Medarbejder> medarbejderliste = new List<Medarbejder>
        {
            new Medarbejder("Admin", "Admin123")
        };
        private static List<Besøg> gæsteliste = new List<Besøg>();
        private static Random rnd = new Random();

        public static void VisMenu()
>>>>>>> 321326faa388b69de7465d748bb1fa0487b4fba3
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("HYDAC Komme-gå-system");
                Console.WriteLine("--------------------");
<<<<<<< HEAD
                if (!erLoggetind)
                    Console.WriteLine("1. Login");
=======
                if (!erLoggetInd)
                    Console.WriteLine("1. Log ind");
>>>>>>> 321326faa388b69de7465d748bb1fa0487b4fba3
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
<<<<<<< HEAD
                        if (!erLoggetind)
                            Login();
                        else
                            LogOut();
                        break;
                    case "2":
                        AddBesøg();
                        break;
                    case "3":
                        OpretMedarbejder();
                        break;
                    case "4":
                        ListeMedarbejder();
                        break;
                    case "5":
                        ListeBesøg();
=======
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
>>>>>>> 321326faa388b69de7465d748bb1fa0487b4fba3
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

<<<<<<< HEAD
        // ---------- Medarbejder ----------

        public void OpretMedarbejder()
        {
            if (erLoggetind == true)
            {
                Console.Clear();
                Console.WriteLine("Opret Medarbejder");
                Console.WriteLine("--------------------");
                Console.Write("Indsæt Brugernavn: ");
                string? brugernavn = Console.ReadLine();
                Console.Write("Indsæt Kode: ");
                string? kode = Console.ReadLine();

                MedarbejderListe.Add(new Medarbejder(brugernavn, kode));
                Console.WriteLine("---Bruger oprettet---");
                erLoggetind = false;
            }
            else
                Console.WriteLine("Du skal være logget ind!");
            Console.ReadLine();
        }

        public void ListeMedarbejder()
        {
            if (erLoggetind) {
                Console.Clear();
                Console.WriteLine("Liste af Medarbejder");
                Console.WriteLine($"{"Brugernavn",-10}");
                Console.WriteLine(new string('-', 10));

                foreach (Medarbejder m in MedarbejderListe)
                {
                    Console.WriteLine($"{m.Brugernavn,-10}");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter for at komme tilbage...");
            }
            else
                Console.WriteLine("Du skal være logget ind!");
                Console.ReadLine();
        }

        public void Login()
=======
        private static void LogInd()
>>>>>>> 321326faa388b69de7465d748bb1fa0487b4fba3
        {
            Console.Clear();
            Console.WriteLine("Log ind");
            Console.WriteLine("--------------------");
<<<<<<< HEAD
            if (erLoggetind == false)
            {
                Console.Write("Indtast Brugernavn: ");
                string? brugernavn = Console.ReadLine();
                Console.Write("Indtast Adgangskode: ");
                string? kode = Console.ReadLine();


                foreach (Medarbejder m in MedarbejderListe)
                {
                    if (m.Brugernavn == brugernavn && m.Kode == kode)
                    {
                        erLoggetind = true;
                        aktivMedarbejder = brugernavn;
                    }
                    else
                        erLoggetind = false;
                }


                if (erLoggetind == true)
                {
                    Console.WriteLine("Login korrekt ");
                }
                else
                    Console.WriteLine("Forkert brugernavn eller kode");
            }
            else
                Console.WriteLine("Du er allerede logget ind");
            Console.Write("Enter for at komme tilbage...");
            Console.ReadLine();
        }

        public void LogOut()
        {
            erLoggetind = false;
            Console.WriteLine("Du er logget ud!");
            Console.ReadLine();
            aktivMedarbejder = "";
        }

        // ---------- Besøg ----------

        public void AddBesøg()
        {

            if (erLoggetind == true)
            {
                Console.Clear();
                Console.WriteLine("Opret Besøg");
                Console.Write("Indtast Navn: ");
                string? navn = Console.ReadLine();
                Console.Write("Indtast Firma: ");
                string? firma = Console.ReadLine();
                Console.Write("Indtast Dato: ");
                DateTime date = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Indtast Forventet Ankomst: ");
                DateTime forventetankomst = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Indtast Forventet Afgang: ");
                DateTime forventetafgang = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Indtast Lokale: ");
                string? lokale = Console.ReadLine();
                Console.Write("Indtast Ansvarlig: ");
                string? ansvarlig = Console.ReadLine();

                Random rnd = new Random();
                int indtjekningskode = rnd.Next(10_000_000, 100_000_000);

                DateTime indtjektid = Convert.ToDateTime(null);
                DateTime udtjektid = Convert.ToDateTime(null);
                string status = "Ikke Tjekket Ind";
                bool sikkerhedsfolder = false;
                BesøgListe.Add(new Besøg(navn, firma, ansvarlig, forventetankomst, forventetafgang, date, indtjektid, udtjektid, lokale, indtjekningskode, status, sikkerhedsfolder));
            }
            else {
                Console.WriteLine("Du skal være logget ind!");
                Console.ReadLine();
            }

        }

        public void ListeBesøg()
        {
            if (erLoggetind)
            {
                Console.Clear();
                Console.WriteLine("Liste Besøg");
                Console.WriteLine($"{"Navn",-12}" +
                        $"{"Firma",-15}" +
                        $"{"Ankomst",-8}" +
                        $"{"Afgang",-8}" +
                        $"{"Lokale",-8}" +
                        $"{"Ansvarlig",-15}" +
                        $"{"Status",-18}" +
                        $"{"Dato",-10}"+
                        $"{"Indtjek",-12}" +
                        $"{"Udtjek",-12}" +
                        $"{"Kode",-10}" +
                        $"{"SF",-6}");

                Console.WriteLine(new string('-', 133));

                foreach (Besøg b in BesøgListe)
                {
                    Console.WriteLine($"{b.Navn,-12}" +
                        $"{b.Firma,-15}" +
                        $"{b.ForventetAnkomst,-8:HH:mm}" +
                        $"{b.ForventetAfgang,-8:HH:mm}" +
                        $"{b.Lokale,-8}" +
                        $"{b.Ansvarlig,-15}" +
                        $"{b.Status,-18}" +
                        $"{b.Date,-10:dd:MM:yy}" +
                        $"{b.IndTjekTid,-12:HH:mm}" +
                        $"{b.UdTjekTid,-12:HH:mm}" +
                        $"{b.IndtjekningsKode,-10}" +
                        $"{b.Sikkerhedsfolder,-16}");
                }
            }
            else
                Console.WriteLine("Du skal være logget ind!");
            Console.ReadLine();
        }

        public void TjekInd()
        {
            Console.Clear();
            Console.Write("Indsæt indtjekningskode: ");
            if (!int.TryParse(Console.ReadLine(), out int indtjekningskode)) {
                Console.Clear();
                Console.WriteLine("Prøv igen");
                Console.Write("Indsæt indtjekningskode: ");
            }
            foreach (Besøg b in BesøgListe)
            {
                if(b.IndtjekningsKode == indtjekningskode && b.Status == "Ikke Tjekket Ind")
                {
                    Console.Clear();
                    b.Status = "Tjekket Ind";
                    b.IndTjekTid = DateTime.Now;
                    Console.Write("Har du modtaget sikkerhedsfolder? ja/nej: ");
                    string? svar = Console.ReadLine().ToLower();
                    if (svar == "ja")
                        b.Sikkerhedsfolder = true;
                    else
                        b.Sikkerhedsfolder = false;

                }
            }
            Console.Write("Enter for at komme tilbage...");
            Console.ReadLine();
        }

        public void TjekUd()
        {
            Console.Clear();
            Console.Write("Indsæt indtjekningskode: ");
            if (!int.TryParse(Console.ReadLine(), out int indtjekningskode))
            {
                Console.Clear();
                Console.WriteLine("Prøv igen");
                Console.Write("Indsæt indtjekningskode: ");
            }
            foreach (Besøg b in BesøgListe)
            {
                if (b.IndtjekningsKode == indtjekningskode && b.Status == "Tjekket Ind")
                {
                    Console.Clear();
                    b.Status = "Tjekket Ud";
                    b.UdTjekTid = DateTime.Now;

                }
            }
=======
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

        private static void LogUd()
        {
            erLoggetInd = false;
            aktivMedarbejder = null;
            Console.WriteLine("Du er logget ud");
            VentPåEnter();
        }

        // UC01 Opret medarbejder
        private static void OpretMedarbejder()
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
        private static void OpretBesøg()
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
        private static void VisMedarbejderliste()
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
        private static void VisGæsteliste()
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
        private static void TjekInd()
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
        private static void TjekUd()
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

        private static Medarbejder? FindMedarbejder(string brugernavn)
        {
            foreach (Medarbejder m in medarbejderliste)
            {
                if (m.Brugernavn == brugernavn)
                    return m;
            }
            return null;
        }

        private static Besøg? FindBesøg(int indtjekningskode)
        {
            foreach (Besøg b in gæsteliste)
            {
                if (b.Indtjekningskode == indtjekningskode)
                    return b;
            }
            return null;
        }

        // 8-cifret kode, som ikke allerede er brugt på gæstelisten
        private static int GenererIndtjekningskode()
        {
            int indtjekningskode;
            do
            {
                indtjekningskode = rnd.Next(10_000_000, 100_000_000);
            } while (FindBesøg(indtjekningskode) != null);
            return indtjekningskode;
        }

        private static void VentPåEnter()
        {
>>>>>>> 321326faa388b69de7465d748bb1fa0487b4fba3
            Console.Write("Enter for at komme tilbage...");
            Console.ReadLine();
        }
    }
}
