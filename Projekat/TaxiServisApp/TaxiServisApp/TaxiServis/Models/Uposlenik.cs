using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
    abstract public class Uposlenik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int id { get; set; }
         string ime { get; set; }
         string prezime { get; set; }
         DateTime datumRodjenja { get; set; }
         string korisnickoIme { get; set; }
         string sifra { get; set; }

       /* Uposlenik(int id,string ime, string prezime, DateTime datumRodjenja, string korisnickoIme, string Sifra)
        {
            this.id = id;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
        }*/

        public Uposlenik(int id, string ime, string prezime, DateTime datumRodjenja, string korisnickoIme, string sifra)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
        }

        public Uposlenik()
        {
        }
    }
}
