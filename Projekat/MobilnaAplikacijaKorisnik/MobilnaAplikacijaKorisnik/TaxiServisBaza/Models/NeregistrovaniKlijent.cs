using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilnaAplikacijaKorisnik.TaxiServisBaza.Models
{
    public class NeregistrovaniKlijent:Klijent
    {
        NeregistrovaniKlijent(int id, Lokacija trenutnaLokacija) : base(id, trenutnaLokacija) { }
    }
}
