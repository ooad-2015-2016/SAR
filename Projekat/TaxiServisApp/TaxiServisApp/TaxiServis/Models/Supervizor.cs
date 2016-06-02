﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp.TaxiServis.Models
{
   public class Supervizor:Uposlenik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

       public  Supervizor(int id, string ime, string prezime, DateTime datumRodjenja, string korisnickoIme, string Sifra)
             : base(id, ime, prezime, datumRodjenja, korisnickoIme, Sifra)  { }

        public Supervizor()
        {
        }
    }
}
