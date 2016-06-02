using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiServisApp.TaxiServis.Models
{
    public class TaxiVozilo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string boja { get; set; }
        public string proizvodjac { get; set; }
        public DateTime godiste { get; set; }
        public string opis { get; set; }
        public TaxiVozilo(int id, string boja, string proizvodjac, DateTime godiste, string opis)
        {
            this.id = id;
            this.boja = boja;
            this.proizvodjac = proizvodjac;
            this.godiste = godiste;
            this.opis = opis;
            
        }

        public TaxiVozilo()
        {
        }

        public bool ispravnoGodiste()
        {
            if (godiste > DateTime.Now) return false;
            return true;
        }
    }
}