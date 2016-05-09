using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
    public class Prijava
    {
        int id { get; set; }

        string korisnickoIme { get; set; }
        string sifra { get; set; }

        public Prijava(string korisnickoIme, string Sifra)
        {
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
        }

        public void validirajPrijavu() { }
        public void prijaviSe() { }

    }

}
