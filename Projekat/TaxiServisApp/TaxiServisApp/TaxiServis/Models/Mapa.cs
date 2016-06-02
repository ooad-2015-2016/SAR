using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp.TaxiServis.Models
{
    public class Mapa
    {
        BingMaps mapControl { get; set; }

        Mapa(BingMaps mapControl)
        {
            this.mapControl = mapControl;
        }
    }
}
