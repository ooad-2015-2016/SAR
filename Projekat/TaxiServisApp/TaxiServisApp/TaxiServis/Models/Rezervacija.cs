using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
    public class Rezervacija:ZahtjevZaPrijevoz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public Lokacija polaznaLokacija { get; set; }
        public DateTime vrijemeRezervacije { get; set; }
        public String dodatniZahtjevi { get; set; }

        public Rezervacija(int id, DateTime vrijemeNarudzbe, Klijent klijent, Vozac idVozačPrihvatio,
            Lokacija odrediste, StatusNarudzbe statusNarudzbe,
            Lokacija polaznaLokacija,DateTime vrijemeRezervacije, string dodatniZahtjevi):
                base(id,vrijemeNarudzbe,klijent,idVozačPrihvatio,odrediste,statusNarudzbe)
        {
            this.polaznaLokacija = polaznaLokacija;
            this.vrijemeRezervacije = vrijemeRezervacije;
            this.dodatniZahtjevi = dodatniZahtjevi;
        }
    }
}
