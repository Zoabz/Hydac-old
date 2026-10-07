using System;

namespace Hydac
{
    // Domæneklasse. Koden er privat og kan kun kontrolleres med TjekKode.
    public class Medarbejder
    {
        public string Brugernavn { get; }
        private string kode;

        public Medarbejder(string brugernavn, string kode)
        {
            Brugernavn = brugernavn;
            this.kode = kode;
        }

        public bool TjekKode(string kode)
        {
            return this.kode == kode;
        }
    }
}
