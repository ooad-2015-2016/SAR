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

        public int polaznaLokacijaId { get; set; }
        [ForeignKey("polaznaLokacijaId")]
        public virtual Lokacija Lokacija { get; set; }
        public DateTime vrijemeRezervacije { get; set; }
        public string dodatniZahtjevi { get; set; }

        public Rezervacija(int id, DateTime vrijemeNarudzbe, RegistrovaniKlijent klijent, int VozacPrihvatioId,
            int odrediste, StatusNarudzbe statusNarudzbe,
            int polaznaLokacijaId, DateTime vrijemeRezervacije, string dodatniZahtjevi):
                base(id,vrijemeNarudzbe,klijent, VozacPrihvatioId ,odrediste,statusNarudzbe)
        {
            this.polaznaLokacijaId = polaznaLokacijaId;
            this.vrijemeRezervacije = vrijemeRezervacije;
            this.dodatniZahtjevi = dodatniZahtjevi;
        }
    }
}
