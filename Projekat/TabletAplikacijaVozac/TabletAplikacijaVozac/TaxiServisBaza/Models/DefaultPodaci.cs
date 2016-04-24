using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletAplikacijaVozac.TaxiServisBaza.Models
{
    class DefaultPodaci
    {
        public static void Initialize(UposlenikDbContext context)
        {
            if (!context.Uposlenici.Any())
            {
                context.Uposlenici.AddRange(
                new Uposlenik()
                {
                    id = 0, ime = "X", prezime = "Y", datumRodjenja = Convert.ToDateTime("9/9/1999"), korisnickoIme = "XY", sifra = "XY"
    }
                );
                context.SaveChanges();
            }
        }
    }
}
