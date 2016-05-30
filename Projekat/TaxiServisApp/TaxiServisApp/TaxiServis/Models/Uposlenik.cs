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
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string korisnickoIme { get; set; }
        public string sifra { get; set; }
        public bool online { get; set; }


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
