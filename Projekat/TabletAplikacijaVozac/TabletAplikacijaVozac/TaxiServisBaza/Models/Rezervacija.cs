using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletAplikacijaVozac
{
    public class Rezervacija:ZahtjevZaPrijevoz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int id { get; set; }
        Lokacija polaznaLokacija { get; set; }
        DateTime vrijemeRezervacije { get; set; }
        String dodatniZahtjevi { get; set; }

        public Rezervacija(int id, DateTime vrijemeNarudzbe, Klijent klijent, Vozač idVozačPrihvatio,
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
