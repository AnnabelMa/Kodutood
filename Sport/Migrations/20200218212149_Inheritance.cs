using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Sport.Migrations
{
    public partial class Inheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
name: "FK_Registreering_Sportlane_SportlaneID",
table: "Registreering");

            migrationBuilder.DropIndex(name: "IX_Registreering_SportlaneID", table: "Registreering");

            migrationBuilder.RenameTable(name: "Treener", newName: "Person");
            migrationBuilder.AddColumn<DateTime>(name: "RegistreeringuKP", table: "Person", nullable: true);
            migrationBuilder.AddColumn<string>(name: "Discriminator", table: "Person", nullable: false, maxLength: 128, defaultValue: "Treener");
            migrationBuilder.AlterColumn<DateTime>(name: "PalkamiseKP", table: "Person", nullable: true);
            migrationBuilder.AddColumn<int>(name: "OldId", table: "Person", nullable: true);

            // Copy existing Sportlane data into new Person table.
            migrationBuilder.Sql("INSERT INTO dbo.Person (Perekonnanimi, Eesnimi, PalkamiseKP, RegistreeringuKP, Discriminator, OldId) SELECT Perekonnanimi, Eesnimi, null AS PalkamiseKP, RegistreeringuKP, 'Sportlane' AS Discriminator, ID AS OldId FROM dbo.Sportlane");
            // Fix up existing relationships to match new PK's.
            migrationBuilder.Sql("UPDATE dbo.Registreering SET SportlaneId = (SELECT ID FROM dbo.Person WHERE OldId = Registreering.SportlaneId AND Discriminator = 'Sportlane')");

            // Remove temporary key
            migrationBuilder.DropColumn(name: "OldID", table: "Person");

            migrationBuilder.DropTable(
                name: "Sportlane");

            migrationBuilder.CreateIndex(
                 name: "IX_Registreering_SportlaneID",
                 table: "Registreering",
                 column: "SportlaneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Registreering_Person_SportlaneID",
                table: "Registreering",
                column: "SportlaneID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
