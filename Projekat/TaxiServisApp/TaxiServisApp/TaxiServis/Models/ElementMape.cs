using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp.TaxiServis.Models
{
    public class ElementMape
    {
        TipElementa tipElementa { get; set; }
        Lokacija lokacijaElementa { get; set; }
        int idElementa { get; set; }

        ElementMape(TipElementa tipElementa, Lokacija lokacijaElementa,int idElementa)
        {
            this.tipElementa = tipElementa;
            this.lokacijaElementa = lokacijaElementa;
            this.idElementa = idElementa;
        }
    }
}
