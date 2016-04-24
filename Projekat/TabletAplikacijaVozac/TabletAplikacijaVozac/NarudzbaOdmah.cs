using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletAplikacijaVozac
{
    public class NarudzbaOdmah:ZahtjevZaPrijevoz
    {

        NarudzbaOdmah(int id, DateTime vrijemeNarudzbe, Klijent klijent, Vozač idVozačPrihvatio,  Lokacija odrediste, StatusNarudzbe statusNarudzbe) : base (id, vrijemeNarudzbe, klijent, idVozačPrihvatio, odrediste, statusNarudzbe) { }
        

        
    }
}
