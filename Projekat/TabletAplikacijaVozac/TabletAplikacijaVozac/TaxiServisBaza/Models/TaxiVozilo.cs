using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabletAplikacijaVozac
{
    public class TaxiVozilo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int id { get; set; }
        string boja { get; set; }
        string proizvodjac { get; set; }
        DateTime godiste { get; set; }
        string opis { get; set; }
    }
}