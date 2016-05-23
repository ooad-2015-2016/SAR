using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
   public class Vozac:Uposlenik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public TaxiVozilo vozilo { get; set; }
        public Lokacija trenutnaLokacija { get; set; }
        public bool slobodan { get; set; }
        public bool aktivan { get; set; }

       public Vozac(int id, string ime, string prezime, DateTime datumRodjenja, string korisnickoIme, string Sifra,
           TaxiVozilo vozilo, Lokacija trenutnaLokacija, Boolean slobodan, Boolean aktivan):
               base(id,ime, prezime,datumRodjenja,korisnickoIme,Sifra)
        {
            this.vozilo = vozilo;
            this.trenutnaLokacija = trenutnaLokacija;
            this.slobodan = slobodan;
            this.aktivan = aktivan;
        }

        public Vozac(int id, string ime, string prezime, DateTime datumRodjenja, string korisnickoIme, string sifra) : base(id, ime, prezime, datumRodjenja, korisnickoIme, sifra)
        {
        }

        public Vozac()
        {
        }
    }
}
