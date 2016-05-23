using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
    public class NarudzbaOdmah:ZahtjevZaPrijevoz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public NarudzbaOdmah(int id, DateTime vrijemeNarudzbe, Klijent klijent, Vozac idVozačPrihvatio,  Lokacija odrediste, StatusNarudzbe statusNarudzbe) : base (id, vrijemeNarudzbe, klijent, idVozačPrihvatio, odrediste, statusNarudzbe) { }

        public NarudzbaOdmah()
        {
        }

        public NarudzbaOdmah(int id)
        {
            this.id = id;
        }
    }
}
