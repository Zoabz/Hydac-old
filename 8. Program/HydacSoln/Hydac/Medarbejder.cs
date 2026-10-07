using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.SymbolStore;
using System.Text;
=======
>>>>>>> 321326faa388b69de7465d748bb1fa0487b4fba3

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
<<<<<<< HEAD
            Kode = kode;

        }
=======
            this.kode = kode;
        }

        public bool TjekKode(string kode)
        {
            return this.kode == kode;
        }
>>>>>>> 321326faa388b69de7465d748bb1fa0487b4fba3
    }
}
