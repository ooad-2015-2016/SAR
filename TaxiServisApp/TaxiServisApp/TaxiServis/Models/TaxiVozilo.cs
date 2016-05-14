using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiServisApp
{
    public class TaxiVozilo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int id { get; set; }
        string boja { get; set; }
        string proizvodjac { get; set; }
        DateTime godiste { get; set; }
        string opis { get; set; }
        public TaxiVozilo(int id, string boja, string proizvodjac, DateTime godiste, string opis)
        {
            this.id = id;
            this.boja = boja;
            this.proizvodjac = proizvodjac;
            this.godiste = godiste;
            this.opis = opis;
            
        }
    }
}