using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilnaAplikacijaKorisnik.TaxiServisBaza.Models
{
    class DefaultPodaci
    {
        public static void Initialize(TaxiServisDbContext context)
        {
            if (!context.Uposlenici.Any())
            {
                context.Uposlenici.AddRange(
                new Vozač (0, "X", "Y", Convert.ToDateTime("1/1/1911"), "XY", "XY"));
                context.SaveChanges();
            }
        }

    }
}
