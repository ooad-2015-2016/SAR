using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
   public class Supervizor:Uposlenik
    {
        int id { get; set; }

       public  Supervizor(int id, string ime, string prezime, DateTime datumRodjenja, string korisnickoIme, string Sifra)
             : base(id, ime, prezime, datumRodjenja, korisnickoIme, Sifra)  { }

    }
}
