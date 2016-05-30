using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class RezervacijaDbContext : DbContext
    {
        public DbSet<RegistrovaniKlijent> RegistrovaniKlijenti { get; set; }
        public DbSet<Lokacija> Lokacije { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}