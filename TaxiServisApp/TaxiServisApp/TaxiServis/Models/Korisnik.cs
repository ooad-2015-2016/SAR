using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;

namespace TaxiServisApp.TaxiServis.Models
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string KorisnickoIme { get; set; }

        public string Sifra { get; set; }
        public DateTime? DatumVrijemeZadnjegPristupa { get; set; }
        public bool? Aktivan { get; set; }
        public virtual ICollection<UlogaKorisnik> UlogaKorisnika //Predstavlja listu korisničkih uloga
        {
            get;
            set;
        }
        public Korisnik()
        {
            UlogaKorisnika = new List<UlogaKorisnik>();
        }
        //dodavanje uloga korisniku
        public void DodajUloguKorisnika(Uloga uloga)
        {

            UlogaKorisnika = UlogaKorisnika.Distinct().ToList();
            this.UlogaKorisnika.Add(new UlogaKorisnik(uloga, this));
        }
    }
}

