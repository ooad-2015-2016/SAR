using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace TabletAplikacijaVozacMigrations
{
    public partial class Migration2 : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "id",
                table: "Uposlenik",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "id",
                table: "Uposlenik",
                type: "INTEGER",
                nullable: false);
                //.Annotation("Sqlite:Autoincrement", true);
        }
    }
}
