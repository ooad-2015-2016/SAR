using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace TabletAplikacijaVozac.TaxiServisBaza.Models
{
    class ZahtjevZaPrijevozDbContext : ZahtjevZaPrijevoz
    {
        public DbSet<ZahtjevZaPrijevoz> ZahtjeviZaPrijevoz { get; set; }

        protected  void OnConfiguring(Microsoft.Data.Entity.DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "TaxiServisBaza.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path,
               databaseFilePath);
            }
            catch (InvalidOperationException) { }
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
    }
}
