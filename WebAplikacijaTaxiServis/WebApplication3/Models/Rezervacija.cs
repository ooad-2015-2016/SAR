using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Rezervacija
    {

        public int Id { get; set; }
       
        public int vrijemeRezervacije { get; set; }
        public String dodatniZahtjevi { get; set; }

        public Rezervacija()
        { }

        public Rezervacija(
             int vrijemeRezervacije, string dodatniZahtjevi) 
                
        {
            
            this.vrijemeRezervacije = vrijemeRezervacije;
            this.dodatniZahtjevi = dodatniZahtjevi;
        }
    }
}