using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;

namespace TaxiServisApp
{
    public class ZahtjevZaPrevozZaListe
    {
        public ZahtjevZaPrevozZaListe(int id)
        {
            this.id = id;
        }

        public ZahtjevZaPrevozZaListe()
        {
        }

        public int id { get; set; }
        public string klijent { get; set; }
        public TipZahtjevaZaPrevoz tipZahtjeva { get; set; }
        public string tipZahtjevaString { get; set; }
        public string lokacija { get; set; }
        public TimeSpan vrijemeCekanja { get; set; }
        public DateTime vrijemeNarudzbe { get; set; }
        public StatusNarudzbe statusNarudzbe { get; set; }
        public string vrijemeCekanjaString { get; set; }
        public string vrijemeNarudzbeString { get; set; }
       public string krajnjaLokacija { get; set; }

    }
}
