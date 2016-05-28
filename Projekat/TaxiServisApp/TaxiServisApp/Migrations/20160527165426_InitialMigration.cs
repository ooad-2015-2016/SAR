using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace TaxiServisAppMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Dispecer",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false),
                    //    .Annotation("Sqlite:Autoincrement", true),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true),
                    prezime = table.Column(type: "TEXT", nullable: true),
                    sifra = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispecer", x => x.id);
                });
            migration.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false),
                    // .Annotation("Sqlite:Autoincrement", true),
                    duzina = table.Column(type: "TEXT", nullable: true),
                    sirina = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.id);
                });
            migration.CreateTable(
                name: "SesijaKlijent",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false),
                    //.Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesijaKlijent", x => x.id);
                });
            migration.CreateTable(
                name: "Supervizor",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false),
                    // .Annotation("Sqlite:Autoincrement", true),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true),
                    prezime = table.Column(type: "TEXT", nullable: true),
                    sifra = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervizor", x => x.id);
                });
            migration.CreateTable(
                name: "TaxiVozilo",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false),
                    //        .Annotation("Sqlite:Autoincrement", true),
                    boja = table.Column(type: "TEXT", nullable: true),
                    godiste = table.Column(type: "TEXT", nullable: false),
                    opis = table.Column(type: "TEXT", nullable: true),
                    proizvodjac = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiVozilo", x => x.id);
                });
            migration.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false),
                    // ,//.Annotation("Sqlite:Autoincrement", true),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true),
                    prezime = table.Column(type: "TEXT", nullable: true),
                    sifra = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.id);
                });
            migration.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        ,//.Annotation("Sqlite:Autoincrement", true),
                    trenutnaLokacijaid = table.Column(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.id);
                    table.ForeignKey(
                        name: "FK_Klijent_Lokacija_trenutnaLokacijaid",
                        columns: x => x.trenutnaLokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "NeregistrovaniKlijent",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        ,//.Annotation("Sqlite:Autoincrement", true),
                    trenutnaLokacijaid = table.Column(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeregistrovaniKlijent", x => x.id);
                    table.ForeignKey(
                        name: "FK_NeregistrovaniKlijent_Lokacija_trenutnaLokacijaid",
                        columns: x => x.trenutnaLokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "RegistrovaniKlijent",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        ,//.Annotation("Sqlite:Autoincrement", true),
                    brojVoznji = table.Column(type: "INTEGER", nullable: false),
                    datumRegistracije = table.Column(type: "TEXT", nullable: false),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    datumZadnjePrijave = table.Column(type: "TEXT", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    kilometriVoznje = table.Column(type: "INTEGER", nullable: false),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true),
                    mail = table.Column(type: "TEXT", nullable: true),
                    online = table.Column(type: "INTEGER", nullable: false),
                    prezime = table.Column(type: "TEXT", nullable: true),
                    sifra = table.Column(type: "TEXT", nullable: true),
                    spol = table.Column(type: "INTEGER", nullable: false),
                    trenutnaLokacijaid = table.Column(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrovaniKlijent", x => x.id);
                    table.ForeignKey(
                        name: "FK_RegistrovaniKlijent_Lokacija_trenutnaLokacijaid",
                        columns: x => x.trenutnaLokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "Vozac",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        ,//.Annotation("Sqlite:Autoincrement", true),
                    aktivan = table.Column(type: "INTEGER", nullable: false),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true),
                    prezime = table.Column(type: "TEXT", nullable: true),
                    sifra = table.Column(type: "TEXT", nullable: true),
                    slobodan = table.Column(type: "INTEGER", nullable: false),
                    trenutnaLokacijaid = table.Column(type: "INTEGER", nullable: true),
                    voziloid = table.Column(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozac", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vozac_Lokacija_trenutnaLokacijaid",
                        columns: x => x.trenutnaLokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_Vozac_TaxiVozilo_voziloid",
                        columns: x => x.voziloid,
                        referencedTable: "TaxiVozilo",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "NarudzbaOdmah",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        ,//.Annotation("Sqlite:Autoincrement", true),
                    idVozačPrihvatioid = table.Column(type: "INTEGER", nullable: true),
                    klijentid = table.Column(type: "INTEGER", nullable: true),
                    lokacijaKorisikaid = table.Column(type: "INTEGER", nullable: true),
                    statusNarudzbe = table.Column(type: "INTEGER", nullable: false),
                    vrijemeNarudzbe = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaOdmah", x => x.id);
                    table.ForeignKey(
                        name: "FK_NarudzbaOdmah_Vozac_idVozačPrihvatioid",
                        columns: x => x.idVozačPrihvatioid,
                        referencedTable: "Vozac",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_NarudzbaOdmah_RegistrovaniKlijent_klijentid",
                        columns: x => x.klijentid,
                        referencedTable: "RegistrovaniKlijent",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_NarudzbaOdmah_Lokacija_lokacijaKorisikaid",
                        columns: x => x.lokacijaKorisikaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        ,//.Annotation("Sqlite:Autoincrement", true),
                    dodatniZahtjevi = table.Column(type: "TEXT", nullable: true),
                    idVozačPrihvatioid = table.Column(type: "INTEGER", nullable: true),
                    klijentid = table.Column(type: "INTEGER", nullable: true),
                    lokacijaKorisikaid = table.Column(type: "INTEGER", nullable: true),
                    polaznaLokacijaid = table.Column(type: "INTEGER", nullable: true),
                    statusNarudzbe = table.Column(type: "INTEGER", nullable: false),
                    vrijemeNarudzbe = table.Column(type: "TEXT", nullable: false),
                    vrijemeRezervacije = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Vozac_idVozačPrihvatioid",
                        columns: x => x.idVozačPrihvatioid,
                        referencedTable: "Vozac",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_Rezervacija_RegistrovaniKlijent_klijentid",
                        columns: x => x.klijentid,
                        referencedTable: "RegistrovaniKlijent",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_Rezervacija_Lokacija_lokacijaKorisikaid",
                        columns: x => x.lokacijaKorisikaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_Rezervacija_Lokacija_polaznaLokacijaid",
                        columns: x => x.polaznaLokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "NarudzbaNeregistrovanogKlijenta",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        ,//.Annotation("Sqlite:Autoincrement", true),
                    idVozačPrihvatioid = table.Column(type: "INTEGER", nullable: true),
                    klijentid = table.Column(type: "INTEGER", nullable: true),
                    lokacijaKorisikaid = table.Column(type: "INTEGER", nullable: true),
                    statusNarudzbe = table.Column(type: "INTEGER", nullable: false),
                    vrijemeNarudzbe = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaNeregistrovanogKlijenta", x => x.id);
                    table.ForeignKey(
                        name: "FK_NarudzbaNeregistrovanogKlijenta_Vozac_idVozačPrihvatioid",
                        columns: x => x.idVozačPrihvatioid,
                        referencedTable: "Vozac",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_NarudzbaNeregistrovanogKlijenta_RegistrovaniKlijent_klijentid",
                        columns: x => x.klijentid,
                        referencedTable: "RegistrovaniKlijent",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_NarudzbaNeregistrovanogKlijenta_Lokacija_lokacijaKorisikaid",
                        columns: x => x.lokacijaKorisikaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "ZahtjevZaPrijevoz",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        ,//.Annotation("Sqlite:Autoincrement", true),
                    idVozačPrihvatioid = table.Column(type: "INTEGER", nullable: true),
                    klijentid = table.Column(type: "INTEGER", nullable: true),
                    lokacijaKorisikaid = table.Column(type: "INTEGER", nullable: true),
                    statusNarudzbe = table.Column(type: "INTEGER", nullable: false),
                    vrijemeNarudzbe = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtjevZaPrijevoz", x => x.id);
                    table.ForeignKey(
                        name: "FK_ZahtjevZaPrijevoz_Vozac_idVozačPrihvatioid",
                        columns: x => x.idVozačPrihvatioid,
                        referencedTable: "Vozac",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_ZahtjevZaPrijevoz_RegistrovaniKlijent_klijentid",
                        columns: x => x.klijentid,
                        referencedTable: "RegistrovaniKlijent",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_ZahtjevZaPrijevoz_Lokacija_lokacijaKorisikaid",
                        columns: x => x.lokacijaKorisikaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Dispecer");
            migration.DropTable("Klijent");
            migration.DropTable("NarudzbaOdmah");
            migration.DropTable("NeregistrovaniKlijent");
            migration.DropTable("Rezervacija");
            migration.DropTable("SesijaKlijent");
            migration.DropTable("Supervizor");
            migration.DropTable("NarudzbaNeregistrovanogKlijenta");
            migration.DropTable("Uposlenik");
            migration.DropTable("ZahtjevZaPrijevoz");
            migration.DropTable("Vozac");
            migration.DropTable("RegistrovaniKlijent");
            migration.DropTable("TaxiVozilo");
            migration.DropTable("Lokacija");
        }
    }
}
