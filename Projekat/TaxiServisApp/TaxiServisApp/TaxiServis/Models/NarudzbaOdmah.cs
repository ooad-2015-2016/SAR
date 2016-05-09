using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
    public class NarudzbaOdmah:ZahtjevZaPrijevoz
    {
        int id { get; set; }
        public NarudzbaOdmah(int id, DateTime vrijemeNarudzbe, Klijent klijent, Vozač idVozačPrihvatio,  Lokacija odrediste, StatusNarudzbe statusNarudzbe) : base (id, vrijemeNarudzbe, klijent, idVozačPrihvatio, odrediste, statusNarudzbe) { }
        

        
    }
}
