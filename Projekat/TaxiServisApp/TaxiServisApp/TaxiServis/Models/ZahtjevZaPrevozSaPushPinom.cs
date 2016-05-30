using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Maps;

namespace TaxiServisApp.TaxiServis.Models
{
    public class ZahtjevZaPrevozSaPushPinom
    {
        public int idZahtjeva { get; set; }
        public MapIcon pin { get; set; }
        public TipZahtjevaZaPrevoz tipZahtjevaZaPrevoz {get; set; }
        public ZahtjevZaPrevozZaListe zahtjevaZaPrevozZaListe { get; set; }
    }
}
