using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletAplikacijaVozac
{
   public class Vozač:Uposlenik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int id { get; set; }
         TaxiVozilo vozilo { get; set; }
         Lokacija trenutnaLokacija { get; set; }
         bool slobodan { get; set; }
         bool aktivan { get; set; }

       Vozač(int id, string ime, string prezime, DateTime datumRodjenja, string korisnickoIme, string Sifra,
           TaxiVozilo vozilo, Lokacija trenutnaLokacija, Boolean slobodan, Boolean aktivan):
               base(id,ime, prezime,datumRodjenja,korisnickoIme,Sifra)
        {
            this.vozilo = vozilo;
            this.trenutnaLokacija = trenutnaLokacija;
            this.slobodan = slobodan;
            this.aktivan = aktivan;
        }

        public Vozač(int id, string ime, string prezime, DateTime datumRodjenja, string korisnickoIme, string sifra) : base(id, ime, prezime, datumRodjenja, korisnickoIme, sifra)
        {
        }
    }
}
