using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;

namespace TaxiServisApp
{
   public class Vozac:Uposlenik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int voziloId { get; set; }
        [ForeignKey("voziloId")]
        public virtual TaxiVozilo TaxiVozilo { get; set; }
        public int trenutnaLokacijaId { get; set; }
        [ForeignKey("trenutnaLokacijaId")]
        public virtual Lokacija Lokacija { get; set; }
        public bool slobodan { get; set; }
        public bool aktivan { get; set; }

       public Vozac(int id, string ime, string prezime, DateTime datumRodjenja, string korisnickoIme, string Sifra,
           TaxiVozilo vozilo, Lokacija trenutnaLokacija, Boolean slobodan, Boolean aktivan):
               base(id,ime, prezime,datumRodjenja,korisnickoIme,Sifra)
        {
            this.voziloId = voziloId;
            this.trenutnaLokacijaId = trenutnaLokacijaId;
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
