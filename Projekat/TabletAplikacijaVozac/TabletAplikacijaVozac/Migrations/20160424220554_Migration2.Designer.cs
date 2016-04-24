using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using TabletAplikacijaVozac.TaxiServisBaza.Models;

namespace TabletAplikacijaVozacMigrations
{
    [ContextType(typeof(UposlenikDbContext))]
    partial class Migration2
    {
        public override string Id
        {
            get { return "20160424220554_Migration2"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("TabletAplikacijaVozac.TaxiServisBaza.Models.Uposlenik", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<string>("ime");

                    b.Property<string>("korisnickoIme");

                    b.Property<string>("prezime");

                    b.Property<string>("sifra");

                    b.Key("id");
                });
        }
    }
}
