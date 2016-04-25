using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace TabletAplikacijaVozacMigrations
{
    public partial class MigracijaRegistrovaniKlijent : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "RegistrovaniKlijent",
                columns: table => new
                {
                    id = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
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
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("RegistrovaniKlijent");
        }
    }
}
