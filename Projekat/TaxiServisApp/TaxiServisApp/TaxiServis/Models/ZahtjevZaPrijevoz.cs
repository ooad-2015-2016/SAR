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
        public int klijentId { get; set; }
        [ForeignKey("klijentId")]
        public virtual RegistrovaniKlijent RegistrovaniKlijent { get; set; }
        public int VozacPrihvatioId { get; set; }
        [ForeignKey("VozacPrihvatioId")]
        public virtual Vozac Vozac { get; set; }
        public int lokacijaKorisikaId { get; set; }
        [ForeignKey("lokacijaKorisikaId")]
        public virtual Lokacija Lokacija { get; set; }
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
        public ZahtjevZaPrijevoz(int id, DateTime vrijemeNarudzbe, RegistrovaniKlijent klijent, int idVozačPrihvatio, int polaziste, StatusNarudzbe statusNarudzbe1)
        {
            this.id = id;
            this.vrijemeNarudzbe = vrijemeNarudzbe;
            this.klijentId = klijentId;
            this.VozacPrihvatioId = idVozačPrihvatio;
            this.lokacijaKorisikaId = polaziste;
            this.statusNarudzbe = statusNarudzbe1;
        }
    }
}
