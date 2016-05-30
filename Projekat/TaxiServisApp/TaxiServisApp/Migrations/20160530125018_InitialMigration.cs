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
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true),
                    online = table.Column(type: "INTEGER", nullable: false),
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
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true),
                    duzina = table.Column(type: "REAL", nullable: false),
                    nazivLokacije = table.Column(type: "TEXT", nullable: true),
                    sirina = table.Column(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.id);
                });
            migration.CreateTable(
                name: "SesijaKlijent",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesijaKlijent", x => x.id);
                });
            migration.CreateTable(
                name: "Supervizor",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true),
                    online = table.Column(type: "INTEGER", nullable: false),
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
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true),
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
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true),
                    online = table.Column(type: "INTEGER", nullable: false),
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
                       ,// .Annotation("Sqlite:Autoincrement", true),
                    Lokacijaid = table.Column(type: "INTEGER", nullable: true),
                    trenutnaLokacijaId = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.id);
                    table.ForeignKey(
                        name: "FK_Klijent_Lokacija_Lokacijaid",
                        columns: x => x.Lokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "NeregistrovaniKlijent",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true),
                    Lokacijaid = table.Column(type: "INTEGER", nullable: true),
                    trenutnaLokacijaId = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeregistrovaniKlijent", x => x.id);
                    table.ForeignKey(
                        name: "FK_NeregistrovaniKlijent_Lokacija_Lokacijaid",
                        columns: x => x.Lokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "RegistrovaniKlijent",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true),
                    Lokacijaid = table.Column(type: "INTEGER", nullable: true),
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
                    trenutnaLokacijaId = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrovaniKlijent", x => x.id);
                    table.ForeignKey(
                        name: "FK_RegistrovaniKlijent_Lokacija_Lokacijaid",
                        columns: x => x.Lokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "Vozac",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true),
                    Lokacijaid = table.Column(type: "INTEGER", nullable: true),
                    TaxiVoziloid = table.Column(type: "INTEGER", nullable: true),
                    aktivan = table.Column(type: "INTEGER", nullable: false),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true),
                    online = table.Column(type: "INTEGER", nullable: false),
                    prezime = table.Column(type: "TEXT", nullable: true),
                    sifra = table.Column(type: "TEXT", nullable: true),
                    slobodan = table.Column(type: "INTEGER", nullable: false),
                    trenutnaLokacijaId = table.Column(type: "INTEGER", nullable: false),
                    voziloId = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozac", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vozac_Lokacija_Lokacijaid",
                        columns: x => x.Lokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_Vozac_TaxiVozilo_TaxiVoziloid",
                        columns: x => x.TaxiVoziloid,
                        referencedTable: "TaxiVozilo",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "NarudzbaOdmah",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true),
                    Lokacijaid = table.Column(type: "INTEGER", nullable: true),
                    RegistrovaniKlijentid = table.Column(type: "INTEGER", nullable: true),
                    VozacPrihvatioId = table.Column(type: "INTEGER", nullable: false),
                    Vozacid = table.Column(type: "INTEGER", nullable: true),
                    klijentId = table.Column(type: "INTEGER", nullable: false),
                    lokacijaKorisikaId = table.Column(type: "INTEGER", nullable: false),
                    statusNarudzbe = table.Column(type: "INTEGER", nullable: false),
                    vrijemeNarudzbe = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaOdmah", x => x.id);
                    table.ForeignKey(
                        name: "FK_NarudzbaOdmah_Lokacija_Lokacijaid",
                        columns: x => x.Lokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_NarudzbaOdmah_RegistrovaniKlijent_RegistrovaniKlijentid",
                        columns: x => x.RegistrovaniKlijentid,
                        referencedTable: "RegistrovaniKlijent",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_NarudzbaOdmah_Vozac_Vozacid",
                        columns: x => x.Vozacid,
                        referencedTable: "Vozac",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true),
                    Lokacijaid = table.Column(type: "INTEGER", nullable: true),
                    RegistrovaniKlijentid = table.Column(type: "INTEGER", nullable: true),
                    VozacPrihvatioId = table.Column(type: "INTEGER", nullable: false),
                    Vozacid = table.Column(type: "INTEGER", nullable: true),
                    dodatniZahtjevi = table.Column(type: "TEXT", nullable: true),
                    klijentId = table.Column(type: "INTEGER", nullable: false),
                    lokacijaKorisikaId = table.Column(type: "INTEGER", nullable: false),
                    polaznaLokacijaId = table.Column(type: "INTEGER", nullable: false),
                    statusNarudzbe = table.Column(type: "INTEGER", nullable: false),
                    vrijemeNarudzbe = table.Column(type: "TEXT", nullable: false),
                    vrijemeRezervacije = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Lokacija_Lokacijaid",
                        columns: x => x.Lokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_Rezervacija_RegistrovaniKlijent_RegistrovaniKlijentid",
                        columns: x => x.RegistrovaniKlijentid,
                        referencedTable: "RegistrovaniKlijent",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_Rezervacija_Vozac_Vozacid",
                        columns: x => x.Vozacid,
                        referencedTable: "Vozac",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "NarudzbaNeregistrovanogKlijenta",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true),
                    Lokacijaid = table.Column(type: "INTEGER", nullable: true),
                    RegistrovaniKlijentid = table.Column(type: "INTEGER", nullable: true),
                    VozacPrihvatioId = table.Column(type: "INTEGER", nullable: false),
                    Vozacid = table.Column(type: "INTEGER", nullable: true),
                    klijentId = table.Column(type: "INTEGER", nullable: false),
                    lokacijaKorisikaId = table.Column(type: "INTEGER", nullable: false),
                    statusNarudzbe = table.Column(type: "INTEGER", nullable: false),
                    vrijemeNarudzbe = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaNeregistrovanogKlijenta", x => x.id);
                    table.ForeignKey(
                        name: "FK_NarudzbaNeregistrovanogKlijenta_Lokacija_Lokacijaid",
                        columns: x => x.Lokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_NarudzbaNeregistrovanogKlijenta_RegistrovaniKlijent_RegistrovaniKlijentid",
                        columns: x => x.RegistrovaniKlijentid,
                        referencedTable: "RegistrovaniKlijent",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_NarudzbaNeregistrovanogKlijenta_Vozac_Vozacid",
                        columns: x => x.Vozacid,
                        referencedTable: "Vozac",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "ZahtjevZaPrijevoz",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                       ,// .Annotation("Sqlite:Autoincrement", true),
                    Lokacijaid = table.Column(type: "INTEGER", nullable: true),
                    RegistrovaniKlijentid = table.Column(type: "INTEGER", nullable: true),
                    VozacPrihvatioId = table.Column(type: "INTEGER", nullable: false),
                    Vozacid = table.Column(type: "INTEGER", nullable: true),
                    klijentId = table.Column(type: "INTEGER", nullable: false),
                    lokacijaKorisikaId = table.Column(type: "INTEGER", nullable: false),
                    statusNarudzbe = table.Column(type: "INTEGER", nullable: false),
                    vrijemeNarudzbe = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtjevZaPrijevoz", x => x.id);
                    table.ForeignKey(
                        name: "FK_ZahtjevZaPrijevoz_Lokacija_Lokacijaid",
                        columns: x => x.Lokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_ZahtjevZaPrijevoz_RegistrovaniKlijent_RegistrovaniKlijentid",
                        columns: x => x.RegistrovaniKlijentid,
                        referencedTable: "RegistrovaniKlijent",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_ZahtjevZaPrijevoz_Vozac_Vozacid",
                        columns: x => x.Vozacid,
                        referencedTable: "Vozac",
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
            migration.DropTable("RegistrovaniKlijent");
            migration.DropTable("Vozac");
            migration.DropTable("Lokacija");
            migration.DropTable("TaxiVozilo");
        }
    }
}
