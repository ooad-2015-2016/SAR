using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Microsoft.CodeAnalysis.CSharp;
using System.Data.Common;
using TaxiServisApp.TaxiServis.Models;

namespace TaxiServisApp
{
    class TaxiServisDbContext : DbContext
    {
        public DbSet<Uposlenik> Uposlenici { get; set; }
        public DbSet<RegistrovaniKlijent> RegistrovaniKlijenti { get; set; }
        public DbSet<TaxiVozilo> TaxiVozila { get; set; }
        public DbSet<ZahtjevZaPrijevoz> ZahtjeviZaPrijevoz { get; set; }
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Lokacija> Lokacije { get; set; }
        public DbSet<NarudzbaOdmah> NarudzbeOdmah { get; set; }

        public DbSet<NarudzbaNeregistrovanogKlijenta> NarudzbeNeregistrovanihKlijenata { get; set; }
        public DbSet<NeregistrovaniKlijent> NeregistrovaniKlijenti { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<SesijaKlijent> SesijeKlijenta { get; set; }
        //public DbSet<Spol> Spolovi { get; set; }
        public DbSet<Supervizor> Supervizori { get; set; }
        public DbSet<Dispecer> Dispeceri { get; set; }
        public DbSet<Vozac> Vozači { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "TaxiServisBazaPodataka28.db";
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
