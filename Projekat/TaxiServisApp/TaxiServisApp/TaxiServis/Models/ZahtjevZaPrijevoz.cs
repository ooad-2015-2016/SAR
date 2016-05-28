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
        public int id { get; set; }
        public DateTime vrijemeNarudzbe { get; set; }
        public RegistrovaniKlijent klijent { get; set; }
        public Vozac idVozačPrihvatio { get; set; }
        public Lokacija lokacijaKorisika { get; set; }
        public StatusNarudzbe statusNarudzbe { get; set; }

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
        public ZahtjevZaPrijevoz() { }
        public ZahtjevZaPrijevoz(int id, DateTime vrijemeNarudzbe, RegistrovaniKlijent klijent, Vozac idVozačPrihvatio, Lokacija polaziste, StatusNarudzbe statusNarudzbe1)
        {
            this.id = id;
            this.vrijemeNarudzbe = vrijemeNarudzbe;
            this.klijent = klijent;
            this.idVozačPrihvatio = idVozačPrihvatio;
            this.lokacijaKorisika = polaziste;
            this.statusNarudzbe = statusNarudzbe1;
        }
    }
}
