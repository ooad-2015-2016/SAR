using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
    public class Dispecer : Uposlenik
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }
        public Dispecer(int id, string ime, string prezime, DateTime datumRodjenja, string korisnickoIme, string Sifra) : base(id, ime, prezime, datumRodjenja, korisnickoIme, Sifra)  { }
    }
}
