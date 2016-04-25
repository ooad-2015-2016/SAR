using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using TabletAplikacijaVozac.TaxiServisBaza.Models;

namespace TabletAplikacijaVozacMigrations
{
    [ContextType(typeof(ZahtjevZaPrijevozDbContext))]
    partial class MigracijaZahtjevZaPrijevoz
    {
        public override string Id
        {
            get { return "20160424232722_MigracijaZahtjevZaPrijevoz"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("TabletAplikacijaVozac.Klijent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("trenutnaLokacijaid");

                    b.Key("id");
                });

            builder.Entity("TabletAplikacijaVozac.Lokacija", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("duzina");

                    b.Property<string>("sirina");

                    b.Key("id");
                });

            builder.Entity("TabletAplikacijaVozac.TaxiServisBaza.Models.ZahtjevZaPrijevoz", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("idVozačPrihvatioid");

                    b.Property<int?>("klijentid");

                    b.Property<int?>("odredisteid");

                    b.Property<DateTime>("vrijemeNarudzbe");

                    b.Key("id");
                });

            builder.Entity("TabletAplikacijaVozac.TaxiVozilo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("boja");

                    b.Property<DateTime>("godiste");

                    b.Property<string>("opis");

                    b.Property<string>("proizvodjac");

                    b.Key("id");
                });

            builder.Entity("TabletAplikacijaVozac.Vozač", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("aktivan");

                    b.Property<bool>("slobodan");

                    b.Property<int?>("trenutnaLokacijaid");

                    b.Property<int?>("voziloid");

                    b.Key("id");
                });

            builder.Entity("TabletAplikacijaVozac.Klijent", b =>
                {
                    b.Reference("TabletAplikacijaVozac.Lokacija")
                        .InverseCollection()
                        .ForeignKey("trenutnaLokacijaid");
                });

            builder.Entity("TabletAplikacijaVozac.TaxiServisBaza.Models.ZahtjevZaPrijevoz", b =>
                {
                    b.Reference("TabletAplikacijaVozac.Vozač")
                        .InverseCollection()
                        .ForeignKey("idVozačPrihvatioid");

                    b.Reference("TabletAplikacijaVozac.Klijent")
                        .InverseCollection()
                        .ForeignKey("klijentid");

                    b.Reference("TabletAplikacijaVozac.Lokacija")
                        .InverseCollection()
                        .ForeignKey("odredisteid");
                });

            builder.Entity("TabletAplikacijaVozac.Vozač", b =>
                {
                    b.Reference("TabletAplikacijaVozac.Lokacija")
                        .InverseCollection()
                        .ForeignKey("trenutnaLokacijaid");

                    b.Reference("TabletAplikacijaVozac.TaxiVozilo")
                        .InverseCollection()
                        .ForeignKey("voziloid");
                });
        }
    }
}
