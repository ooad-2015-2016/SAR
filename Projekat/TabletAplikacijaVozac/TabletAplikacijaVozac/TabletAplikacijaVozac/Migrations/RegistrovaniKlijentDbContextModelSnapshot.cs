using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using TabletAplikacijaVozac.TaxiServisBaza.Models;

namespace TabletAplikacijaVozacMigrations
{
    [ContextType(typeof(RegistrovaniKlijentDbContext))]
    partial class RegistrovaniKlijentDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("TabletAplikacijaVozac.TaxiServisBaza.Models.RegistrovaniKlijent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("brojVoznji");

                    b.Property<DateTime>("datumRegistracije");

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<string>("ime");

                    b.Property<int>("kilometriVoznje");

                    b.Property<string>("korisnickoIme");

                    b.Property<string>("mail");

                    b.Property<string>("prezime");

                    b.Property<string>("sifra");

                    b.Property<int>("spol");

                    b.Key("id");
                });
        }
    }
}
