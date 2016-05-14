using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
    abstract public class ZahtjevZaPrijevoz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
            this.statusNarudzbe = statusNarudzbe1;
        }
    }
}
