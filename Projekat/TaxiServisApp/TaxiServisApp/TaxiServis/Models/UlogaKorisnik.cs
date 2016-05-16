using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;

namespace TaxiServisApp.TaxiServis.Models
{
    public class UlogaKorisnik
    {
        public int UlogaId { get; set; }
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }
        public Uloga Uloga { get; set; }

        public UlogaKorisnik(Uloga uloga, Korisnik korisnik)
        {
            this.Uloga = uloga;
            this.Korisnik = Korisnik;
            this.UlogaId = uloga.UlogaId;
            this.KorisnikId = korisnik.KorisnikId;
        }
    }

}
