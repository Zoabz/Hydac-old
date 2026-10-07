using System;
<<<<<<< HEAD
using System.Collections.Generic;
=======

>>>>>>> 321326faa388b69de7465d748bb1fa0487b4fba3
namespace Hydac
{
    // Domæneklasse. Gæst, Indtjekning og Udtjekning fra domænemodellen er
    // foldet ind i Besøg som attributter (se 0. Ordliste/Ordliste.md).
    public class Besøg
    {
        // Gyldige værdier for Status
        public const string IkkeTjekketInd = "Ikke Tjekket Ind";
        public const string TjekketInd = "Tjekket Ind";
        public const string TjekketUd = "Tjekket Ud";

        // Gæst
        public string GæstNavn { get; }
        public string Firma { get; }

        public Medarbejder Ansvarlig { get; }
        public DateTime Dato { get; }
        public DateTime ForventetAnkomsttid { get; }
        public DateTime ForventetAfgangstid { get; }
        public string Lokale { get; }
        public int Indtjekningskode { get; }
        public string Status { get; private set; }

        // Indtjekning
        public DateTime? Indtjekningstid { get; private set; }
        public bool SikkerhedsfolderModtaget { get; private set; }

        // Udtjekning
        public DateTime? Udtjekningstid { get; private set; }

        public Besøg(string gæstNavn, string firma, Medarbejder ansvarlig, DateTime dato,
            DateTime forventetAnkomsttid, DateTime forventetAfgangstid, string lokale, int indtjekningskode)
        {
            // Udvidelser i UC02 Opret besøg
            if (string.IsNullOrWhiteSpace(gæstNavn) || string.IsNullOrWhiteSpace(firma))
                throw new ArgumentException("Navn og firma skal udfyldes");
            if (dato.Date < DateTime.Today)
                throw new ArgumentException("Datoen må ikke ligge før i dag");
            if (forventetAfgangstid <= forventetAnkomsttid)
                throw new ArgumentException("Afgangstid skal være efter ankomsttid");

            GæstNavn = gæstNavn;
            Firma = firma;
            Ansvarlig = ansvarlig;
            Dato = dato.Date;
            ForventetAnkomsttid = forventetAnkomsttid;
            ForventetAfgangstid = forventetAfgangstid;
            Lokale = lokale;
            Indtjekningskode = indtjekningskode;
            Status = IkkeTjekketInd;
            SikkerhedsfolderModtaget = false;
        }
<<<<<<< HEAD
=======

        // UC05 Tjek gæst ind
        public void TjekInd(bool sikkerhedsfolderModtaget)
        {
            if (Status != IkkeTjekketInd)
                throw new InvalidOperationException("Besøget har status \"" + Status + "\" og kan ikke tjekkes ind");

            Status = TjekketInd;
            Indtjekningstid = DateTime.Now;
            SikkerhedsfolderModtaget = sikkerhedsfolderModtaget;
        }

        // UC06 Tjek gæst ud
        public void TjekUd()
        {
            if (Status != TjekketInd)
                throw new InvalidOperationException("Besøget har status \"" + Status + "\" og kan ikke tjekkes ud");

            Status = TjekketUd;
            Udtjekningstid = DateTime.Now;
        }
>>>>>>> 321326faa388b69de7465d748bb1fa0487b4fba3
    }
}
