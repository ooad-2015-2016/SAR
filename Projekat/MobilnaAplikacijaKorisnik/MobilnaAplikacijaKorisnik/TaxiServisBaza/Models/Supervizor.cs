using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilnaAplikacijaKorisnik.TaxiServisBaza.Models
{
    public class Supervizor:Uposlenik
    {
        Supervizor(int id, string ime, string prezime, DateTime datumRodjenja, string korisnickoIme, string Sifra)
             : base(id, ime, prezime, datumRodjenja, korisnickoIme, Sifra)  { }

    }
}
