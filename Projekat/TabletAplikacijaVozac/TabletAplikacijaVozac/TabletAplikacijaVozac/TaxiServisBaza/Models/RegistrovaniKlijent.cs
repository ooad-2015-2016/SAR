using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletAplikacijaVozac.TaxiServisBaza.Models
{
    class RegistrovaniKlijent
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
    }
}
