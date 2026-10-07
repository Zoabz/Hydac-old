using System;
using System.Collections.Generic;
using System.Text;

namespace Hydac
{
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
        {
            while (true)
            {
                // Vis menuen
                Console.Clear();
                Console.WriteLine("Hydac Komme-Gå-System");
                Console.WriteLine("--------------------");
                if (!erLoggetind)
                    Console.WriteLine("1. Login");
                else
                    Console.WriteLine("1. Log ud");
                Console.WriteLine("2. Opret besøg");
                Console.WriteLine("3. Opret medarbejder");
                Console.WriteLine("4. Vis medarbejder");
                Console.WriteLine("5. Vis besøg");
                Console.WriteLine("6. Tjek Ind");
                Console.WriteLine("7. Tjek Ud");
                Console.WriteLine("--------------------");

                // Input fra aktøren
                Console.Write(aktivMedarbejder + " > ");

                // Menu valg
                string? svar = Console.ReadLine();
                switch (svar) {
                    case "1":
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
                        Console.Write("Enter for at komme tilbage...");
                        Console.ReadLine();
                    break;
                }
            }
        }

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
        {
            Console.Clear();
            Console.WriteLine("Log ind");
            Console.WriteLine("--------------------");
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
            Console.Write("Enter for at komme tilbage...");
            Console.ReadLine();
        }
    }
}
