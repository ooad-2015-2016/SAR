using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using TaxiServisApp;

namespace TaxiServisAppMigrations
{
    [ContextType(typeof(TaxiServisDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160527165426_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("TaxiServisApp.Dispecer", b =>
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

            builder.Entity("TaxiServisApp.Klijent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("trenutnaLokacijaid");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.Lokacija", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("duzina");

                    b.Property<string>("sirina");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.NarudzbaOdmah", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("idVozačPrihvatioid");

                    b.Property<int?>("klijentid");

                    b.Property<int?>("lokacijaKorisikaid");

                    b.Property<int>("statusNarudzbe");

                    b.Property<DateTime>("vrijemeNarudzbe");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.NeregistrovaniKlijent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("trenutnaLokacijaid");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.RegistrovaniKlijent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

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

                    b.Property<int?>("trenutnaLokacijaid");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.Rezervacija", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("dodatniZahtjevi");

                    b.Property<int?>("idVozačPrihvatioid");

                    b.Property<int?>("klijentid");

                    b.Property<int?>("lokacijaKorisikaid");

                    b.Property<int?>("polaznaLokacijaid");

                    b.Property<int>("statusNarudzbe");

                    b.Property<DateTime>("vrijemeNarudzbe");

                    b.Property<DateTime>("vrijemeRezervacije");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.SesijaKlijent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.Supervizor", b =>
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

            builder.Entity("TaxiServisApp.TaxiServis.Models.NarudzbaNeregistrovanogKlijenta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("idVozačPrihvatioid");

                    b.Property<int?>("klijentid");

                    b.Property<int?>("lokacijaKorisikaid");

                    b.Property<int>("statusNarudzbe");

                    b.Property<DateTime>("vrijemeNarudzbe");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.TaxiVozilo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("boja");

                    b.Property<DateTime>("godiste");

                    b.Property<string>("opis");

                    b.Property<string>("proizvodjac");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.Uposlenik", b =>
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

            builder.Entity("TaxiServisApp.Vozac", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("aktivan");

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<string>("ime");

                    b.Property<string>("korisnickoIme");

                    b.Property<string>("prezime");

                    b.Property<string>("sifra");

                    b.Property<bool>("slobodan");

                    b.Property<int?>("trenutnaLokacijaid");

                    b.Property<int?>("voziloid");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.ZahtjevZaPrijevoz", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("idVozačPrihvatioid");

                    b.Property<int?>("klijentid");

                    b.Property<int?>("lokacijaKorisikaid");

                    b.Property<int>("statusNarudzbe");

                    b.Property<DateTime>("vrijemeNarudzbe");

                    b.Key("id");
                });

            builder.Entity("TaxiServisApp.Klijent", b =>
                {
                    b.Reference("TaxiServisApp.Lokacija")
                        .InverseCollection()
                        .ForeignKey("trenutnaLokacijaid");
                });

            builder.Entity("TaxiServisApp.NarudzbaOdmah", b =>
                {
                    b.Reference("TaxiServisApp.Vozac")
                        .InverseCollection()
                        .ForeignKey("idVozačPrihvatioid");

                    b.Reference("TaxiServisApp.RegistrovaniKlijent")
                        .InverseCollection()
                        .ForeignKey("klijentid");

                    b.Reference("TaxiServisApp.Lokacija")
                        .InverseCollection()
                        .ForeignKey("lokacijaKorisikaid");
                });

            builder.Entity("TaxiServisApp.NeregistrovaniKlijent", b =>
                {
                    b.Reference("TaxiServisApp.Lokacija")
                        .InverseCollection()
                        .ForeignKey("trenutnaLokacijaid");
                });

            builder.Entity("TaxiServisApp.RegistrovaniKlijent", b =>
                {
                    b.Reference("TaxiServisApp.Lokacija")
                        .InverseCollection()
                        .ForeignKey("trenutnaLokacijaid");
                });

            builder.Entity("TaxiServisApp.Rezervacija", b =>
                {
                    b.Reference("TaxiServisApp.Vozac")
                        .InverseCollection()
                        .ForeignKey("idVozačPrihvatioid");

                    b.Reference("TaxiServisApp.RegistrovaniKlijent")
                        .InverseCollection()
                        .ForeignKey("klijentid");

                    b.Reference("TaxiServisApp.Lokacija")
                        .InverseCollection()
                        .ForeignKey("lokacijaKorisikaid");

                    b.Reference("TaxiServisApp.Lokacija")
                        .InverseCollection()
                        .ForeignKey("polaznaLokacijaid");
                });

            builder.Entity("TaxiServisApp.TaxiServis.Models.NarudzbaNeregistrovanogKlijenta", b =>
                {
                    b.Reference("TaxiServisApp.Vozac")
                        .InverseCollection()
                        .ForeignKey("idVozačPrihvatioid");

                    b.Reference("TaxiServisApp.RegistrovaniKlijent")
                        .InverseCollection()
                        .ForeignKey("klijentid");

                    b.Reference("TaxiServisApp.Lokacija")
                        .InverseCollection()
                        .ForeignKey("lokacijaKorisikaid");
                });

            builder.Entity("TaxiServisApp.Vozac", b =>
                {
                    b.Reference("TaxiServisApp.Lokacija")
                        .InverseCollection()
                        .ForeignKey("trenutnaLokacijaid");

                    b.Reference("TaxiServisApp.TaxiVozilo")
                        .InverseCollection()
                        .ForeignKey("voziloid");
                });

            builder.Entity("TaxiServisApp.ZahtjevZaPrijevoz", b =>
                {
                    b.Reference("TaxiServisApp.Vozac")
                        .InverseCollection()
                        .ForeignKey("idVozačPrihvatioid");

                    b.Reference("TaxiServisApp.RegistrovaniKlijent")
                        .InverseCollection()
                        .ForeignKey("klijentid");

                    b.Reference("TaxiServisApp.Lokacija")
                        .InverseCollection()
                        .ForeignKey("lokacijaKorisikaid");
                });
        }
    }
}
