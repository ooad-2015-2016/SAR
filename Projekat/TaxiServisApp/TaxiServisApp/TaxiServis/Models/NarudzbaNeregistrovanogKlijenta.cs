using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp.TaxiServis.Models
{
    class NarudzbaNeregistrovanogKlijenta : ZahtjevZaPrijevoz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public NarudzbaNeregistrovanogKlijenta(int id, DateTime vrijemeNarudzbe, RegistrovaniKlijent klijent, int VozacPrihvatioId, int odrediste, StatusNarudzbe statusNarudzbe) : base (id, vrijemeNarudzbe, klijent, VozacPrihvatioId, odrediste, statusNarudzbe) { }

    }
}
