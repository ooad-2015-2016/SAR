using Microsoft.Data.Entity;
using System;
using System.IO;
using Windows.Storage;

namespace MobilnaAplikacijaKorisnik.TaxiServisBaza.Models
{
    class TaxiServisDbContext : DbContext
    {
        public DbSet<Uposlenik> Uposlenici { get; set; }
        public DbSet<RegistrovaniKlijent> RegistrovaniKlijenti { get; set; }
        public DbSet<TaxiVozilo> TaxiVozila { get; set; }
        public DbSet<ZahtjevZaPrijevoz> ZahtjeviZaPrijevoz { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
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
