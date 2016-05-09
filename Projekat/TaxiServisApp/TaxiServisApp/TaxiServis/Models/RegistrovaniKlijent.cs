using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
    public class RegistrovaniKlijent:Klijent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int id { get; set; }
        string ime { get; set; }
        string prezime { get; set; }
        string mail { get; set; }
        string korisnickoIme { get; set; }
        string sifra { get; set; }
        DateTime datumRodjenja { get; set; }
        DateTime datumRegistracije { get; set; }
        Spol spol { get; set; }
        int brojVoznji { get; set; }
        int kilometriVoznje { get; set; }
        
        public RegistrovaniKlijent(int id, string ime,string prezime, string mail,
            string korisnickoIme, string sifra, DateTime datumRodjenja,DateTime datumRegistracije,
            Spol spol,int brojVoznji,int kilometriVoznje)
            : base(id)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.mail = mail;
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
            this.datumRodjenja = datumRodjenja;
            this.datumRegistracije = datumRegistracije;
            this.spol = spol;
            this.brojVoznji=brojVoznji;
            this.kilometriVoznje = kilometriVoznje;
        }

    }
}
