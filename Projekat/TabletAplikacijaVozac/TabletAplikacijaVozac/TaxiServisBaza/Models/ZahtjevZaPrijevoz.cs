using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletAplikacijaVozac.TaxiServisBaza.Models
{
    class ZahtjevZaPrijevoz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime vrijemeNarudzbe { get; set; }
        public Klijent klijent { get; set; }
        public Vozač idVozačPrihvatio { get; set; }
        public Lokacija odrediste { get; set; }
    }
}
