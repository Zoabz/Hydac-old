using System;
using System.Collections.Generic;
namespace Hydac
{
    public class Besøg
    {
        public string Navn { get; set; }
        public string Firma { get; set; }
        public string Ansvarlig { get; set; }
        public DateTime ForventetAnkomst { get; set; }
        public DateTime ForventetAfgang { get; set; }
        public DateTime? IndTjekTid { get; set; }
        public DateTime? UdTjekTid { get; set; }
        public string Lokale { get; set; }
        public int IndtjekningsKode { get; set; }
        public string Status { get; set; }
        public bool Sikkerhedsfolder { get; set; }
        public DateTime? Date { get; set;  }
        
        public Besøg(string navn, string firma, string ansvarlig, DateTime forventetAnkomst, DateTime forventetAfgang,DateTime? date, DateTime? indtjektid,DateTime? udtjektid, string lokale, int indtjekningsKode, string status, bool sikkerhedsfolder)
        {
            Navn = navn;
            Firma = firma;
            Ansvarlig = ansvarlig;
            ForventetAnkomst = forventetAnkomst;
            ForventetAfgang = forventetAfgang;
            Date = date;
            IndTjekTid = indtjektid;
            UdTjekTid = udtjektid;
            Lokale = lokale;
            IndtjekningsKode = indtjekningsKode;
            Status = status;
            Sikkerhedsfolder = sikkerhedsfolder;
            
            
        }
    }
}
