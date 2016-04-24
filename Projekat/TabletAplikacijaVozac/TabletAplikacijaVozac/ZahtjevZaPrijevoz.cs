using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletAplikacijaVozac
{
    abstract public class ZahtjevZaPrijevoz
    {
        private StatusNarudzbe statusNarudzbe1;

        int id { get; set; }
        DateTime vrijemeNarudzbe { get; set; }
        Klijent klijent { get; set; }
        Vozač idVozačPrihvatio { get; set; }
        Lokacija odrediste { get; set; }
        StatusNarudzbe statusNarudzbe { get; set; }

       /* ZahtjevZaPrijevoz(int id,DateTime vrijemeNarudzbe, Klijent klijent, Vozač idVozačPrihvatio, 
            Lokacija odrediste, StatusNarudzbe statusNarudzbe)
        {
            this.id = id;
            this.vrijemeNarudzbe = vrijemeNarudzbe;
            this.klijent = klijent;
            this.idVozačPrihvatio = idVozačPrihvatio;
            this.odrediste = odrediste;
            this.statusNarudzbe = statusNarudzbe;
        }*/

        public ZahtjevZaPrijevoz(int id, DateTime vrijemeNarudzbe, Klijent klijent, Vozač idVozačPrihvatio, Lokacija odrediste, StatusNarudzbe statusNarudzbe1)
        {
            this.id = id;
            this.vrijemeNarudzbe = vrijemeNarudzbe;
            this.klijent = klijent;
            this.idVozačPrihvatio = idVozačPrihvatio;
            this.odrediste = odrediste;
            this.statusNarudzbe1 = statusNarudzbe1;
        }
    }
}
