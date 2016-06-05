using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using TaxiServisApp.TaxiServis.Models;

namespace TaxiServisAppMigrations
{
    [ContextType(typeof(TaxiServisDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160605094934_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("TaxiServisApp.NarudzbaOdmah", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Lokacijaid");

                    b.Property<int?>("RegistrovaniKlijentid");

                    b.Property<int>("VozacPrihvatioId");

                    b.Property<int?>("Vozacid");

                    b.Property<int>("klijentId");

                    b.Property<int>("lokacijaKorisikaId");

                    b.Property<int>("statusNarudzbe");

                    b.Property<DateTime>("vrijemeNarudzbe");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.Cijenovnik", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.Dispecer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<string>("ime");

                    b.Property<string>("korisnickoIme");

                    b.Property<bool>("online");

                    b.Property<string>("prezime");

                    b.Property<string>("sifra");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.Klijent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Lokacijaid");

                    b.Property<int>("trenutnaLokacijaId");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.Lokacija", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("duzina");

                    b.Property<string>("nazivLokacije");

                    b.Property<double>("sirina");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.NarudzbaNeregistrovanogKlijenta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Lokacijaid");

                    b.Property<int?>("RegistrovaniKlijentid");

                    b.Property<int>("VozacPrihvatioId");

                    b.Property<int?>("Vozacid");

                    b.Property<int>("klijentId");

                    b.Property<int>("lokacijaKorisikaId");

                    b.Property<int>("statusNarudzbe");

                    b.Property<DateTime>("vrijemeNarudzbe");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.NeregistrovaniKlijent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Lokacijaid");

                    b.Property<int>("trenutnaLokacijaId");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.RegistrovaniKlijent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Lokacijaid");

                    b.Property<int>("brojVoznji");

                    b.Property<DateTime>("datumRegistracije");

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<DateTime>("datumZadnjePrijave");

                    b.Property<string>("ime");

                    b.Property<int>("kilometriVoznje");

                    b.Property<string>("korisnickoIme");

                    b.Property<string>("mail");

                    b.Property<bool>("online");

                    b.Property<string>("prezime");

                    b.Property<string>("sifra");

                    b.Property<int>("spol");

                    b.Property<int>("trenutnaLokacijaId");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.Rezervacija", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LokacijaKrajnjaid");

                    b.Property<int?>("LokacijaPocetnaid");

                    b.Property<int?>("Lokacijaid");

                    b.Property<int?>("RegistrovaniKlijentid");

                    b.Property<int>("VozacPrihvatioId");

                    b.Property<int?>("Vozacid");

                    b.Property<string>("dodatniZahtjevi");

                    b.Property<int>("klijentId");

                    b.Property<int>("krajnjaLokacijaId");

                    b.Property<int>("lokacijaKorisikaId");

                    b.Property<int>("polaznaLokacijaId");

                    b.Property<int>("statusNarudzbe");

                    b.Property<DateTime>("vrijemeNarudzbe");

                    b.Property<DateTime>("vrijemeRezervacije");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.SesijaKlijent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.Supervizor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<string>("ime");

                    b.Property<string>("korisnickoIme");

                    b.Property<bool>("online");

                    b.Property<string>("prezime");

                    b.Property<string>("sifra");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.TaxiVozilo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("boja");

                    b.Property<DateTime>("godiste");

                    b.Property<string>("opis");

                    b.Property<string>("proizvodjac");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.Uposlenik", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<string>("ime");

                    b.Property<string>("korisnickoIme");

                    b.Property<bool>("online");

                    b.Property<string>("prezime");

                    b.Property<string>("sifra");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.ZahtjevZaPrijevoz", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Lokacijaid");

                    b.Property<int?>("RegistrovaniKlijentid");

                    b.Property<int>("VozacPrihvatioId");

                    b.Property<int?>("Vozacid");

                    b.Property<int>("klijentId");

                    b.Property<int>("lokacijaKorisikaId");

                    b.Property<int>("statusNarudzbe");

                    b.Property<DateTime>("vrijemeNarudzbe");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.Vozac", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Lokacijaid");

                    b.Property<int?>("TaxiVoziloid");

                    b.Property<bool>("aktivan");

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<string>("ime");

                    b.Property<string>("korisnickoIme");

                    b.Property<bool>("online");

                    b.Property<string>("prezime");

                    b.Property<string>("sifra");

                    b.Property<bool>("slobodan");

                    b.Property<int>("trenutnaLokacijaId");

                    b.Property<int>("voziloId");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.NarudzbaOdmah", b =>
                {
                    b.Reference("TaxiServisApp.TaxiServis.Models.Lokacija")
                        .InverseCollection()
                        .ForeignKey("Lokacijaid");

                    b.Reference("TaxiServisApp.TaxiServis.Models.RegistrovaniKlijent")
                        .InverseCollection()
                        .ForeignKey("RegistrovaniKlijentid");

                    b.Reference("TaxiServisApp.Vozac")
                        .InverseCollection()
                        .ForeignKey("Vozacid");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.Klijent", b =>
                {
                    b.Reference("TaxiServisApp.TaxiServis.Models.Lokacija")
                        .InverseCollection()
                        .ForeignKey("Lokacijaid");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.NarudzbaNeregistrovanogKlijenta", b =>
                {
                    b.Reference("TaxiServisApp.TaxiServis.Models.Lokacija")
                        .InverseCollection()
                        .ForeignKey("Lokacijaid");

                    b.Reference("TaxiServisApp.TaxiServis.Models.RegistrovaniKlijent")
                        .InverseCollection()
                        .ForeignKey("RegistrovaniKlijentid");

                    b.Reference("TaxiServisApp.Vozac")
                        .InverseCollection()
                        .ForeignKey("Vozacid");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.NeregistrovaniKlijent", b =>
                {
                    b.Reference("TaxiServisApp.TaxiServis.Models.Lokacija")
                        .InverseCollection()
                        .ForeignKey("Lokacijaid");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.RegistrovaniKlijent", b =>
                {
                    b.Reference("TaxiServisApp.TaxiServis.Models.Lokacija")
                        .InverseCollection()
                        .ForeignKey("Lokacijaid");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.Rezervacija", b =>
                {
                    b.Reference("TaxiServisApp.TaxiServis.Models.Lokacija")
                        .InverseCollection()
                        .ForeignKey("LokacijaKrajnjaid");

                    b.Reference("TaxiServisApp.TaxiServis.Models.Lokacija")
                        .InverseCollection()
                        .ForeignKey("LokacijaPocetnaid");

                    b.Reference("TaxiServisApp.TaxiServis.Models.Lokacija")
                        .InverseCollection()
                        .ForeignKey("Lokacijaid");

                    b.Reference("TaxiServisApp.TaxiServis.Models.RegistrovaniKlijent")
                        .InverseCollection()
                        .ForeignKey("RegistrovaniKlijentid");

                    b.Reference("TaxiServisApp.Vozac")
                        .InverseCollection()
                        .ForeignKey("Vozacid");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.ZahtjevZaPrijevoz", b =>
                {
                    b.Reference("TaxiServisApp.TaxiServis.Models.Lokacija")
                        .InverseCollection()
                        .ForeignKey("Lokacijaid");

                    b.Reference("TaxiServisApp.TaxiServis.Models.RegistrovaniKlijent")
                        .InverseCollection()
                        .ForeignKey("RegistrovaniKlijentid");

                    b.Reference("TaxiServisApp.Vozac")
                        .InverseCollection()
                        .ForeignKey("Vozacid");
                });

            builder.Entity("TaxiServisApp.Vozac", b =>
                {
                    b.Reference("TaxiServisApp.TaxiServis.Models.Lokacija")
                        .InverseCollection()
                        .ForeignKey("Lokacijaid");

                    b.Reference("TaxiServisApp.TaxiServis.Models.TaxiVozilo")
                        .InverseCollection()
                        .ForeignKey("TaxiVoziloid");
                });
        }
    }
}
