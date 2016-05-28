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
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string mail { get; set; }
        public string korisnickoIme { get; set; }
        public string sifra { get; set; }
        public DateTime datumRodjenja { get; set; }
        public DateTime datumRegistracije { get; set; }
        public Spol spol { get; set; }
        public int brojVoznji { get; set; }
        public int kilometriVoznje { get; set; }
        public DateTime datumZadnjePrijave { get; set; }
        public bool online { get; set; }
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
            online = false;
        }

        public RegistrovaniKlijent()
        {
        }
    }
}
