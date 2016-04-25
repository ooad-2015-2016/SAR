using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace TabletAplikacijaVozacMigrations
{
    public partial class MigracijaTaxiServis : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    duzina = table.Column(type: "TEXT", nullable: true),
                    sirina = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.id);
                });
            migration.CreateTable(
                name: "RegistrovaniKlijent",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    brojVoznji = table.Column(type: "INTEGER", nullable: false),
                    datumRegistracije = table.Column(type: "TEXT", nullable: false),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    kilometriVoznje = table.Column(type: "INTEGER", nullable: false),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true),
                    mail = table.Column(type: "TEXT", nullable: true),
                    prezime = table.Column(type: "TEXT", nullable: true),
                    sifra = table.Column(type: "TEXT", nullable: true),
                    spol = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrovaniKlijent", x => x.id);
                });
            migration.CreateTable(
                name: "TaxiVozilo",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "Vozač",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    aktivan = table.Column(type: "INTEGER", nullable: false),
                    slobodan = table.Column(type: "INTEGER", nullable: false),
                    trenutnaLokacijaid = table.Column(type: "INTEGER", nullable: true),
                    voziloid = table.Column(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozač", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vozač_Lokacija_trenutnaLokacijaid",
                        columns: x => x.trenutnaLokacijaid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_Vozač_TaxiVozilo_voziloid",
                        columns: x => x.voziloid,
                        referencedTable: "TaxiVozilo",
                        referencedColumn: "id");
                });
            migration.CreateTable(
                name: "ZahtjevZaPrijevoz",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idVozačPrihvatioid = table.Column(type: "INTEGER", nullable: true),
                    klijentid = table.Column(type: "INTEGER", nullable: true),
                    odredisteid = table.Column(type: "INTEGER", nullable: true),
                    statusNarudzbe = table.Column(type: "INTEGER", nullable: false),
                    vrijemeNarudzbe = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtjevZaPrijevoz", x => x.id);
                    table.ForeignKey(
                        name: "FK_ZahtjevZaPrijevoz_Vozač_idVozačPrihvatioid",
                        columns: x => x.idVozačPrihvatioid,
                        referencedTable: "Vozač",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_ZahtjevZaPrijevoz_Klijent_klijentid",
                        columns: x => x.klijentid,
                        referencedTable: "Klijent",
                        referencedColumn: "id");
                    table.ForeignKey(
                        name: "FK_ZahtjevZaPrijevoz_Lokacija_odredisteid",
                        columns: x => x.odredisteid,
                        referencedTable: "Lokacija",
                        referencedColumn: "id");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("RegistrovaniKlijent");
            migration.DropTable("Uposlenik");
            migration.DropTable("ZahtjevZaPrijevoz");
            migration.DropTable("Vozač");
            migration.DropTable("Klijent");
            migration.DropTable("TaxiVozilo");
            migration.DropTable("Lokacija");
        }
    }
}
