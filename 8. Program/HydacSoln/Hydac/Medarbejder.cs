using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace Hydac
{
    public class Medarbejder
    {
        private string brugernavn;

        public string Brugernavn
        {
            get { return brugernavn; }
            set { brugernavn = value; }
        }

        private string kode;

        public string Kode
        {
            get { return kode; }
            set { kode = value; }
        }

        public Medarbejder(string brugernavn, string kode) {
            Brugernavn = brugernavn;
            Kode = kode;

        }
    }
}
