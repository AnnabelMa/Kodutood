using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sport.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spordiala",
                columns: table => new
                {
                    SpordialaID = table.Column<int>(nullable: false),
                    Nimi = table.Column<string>(nullable: true),
                    Tulemused = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spordiala", x => x.SpordialaID);
                });

            migrationBuilder.CreateTable(
                name: "Sportlane",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Perekonnanimi = table.Column<string>(nullable: true),
                    Eesnimi = table.Column<string>(nullable: true),
                    RegistreeringuKP = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sportlane", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Registreering",
                columns: table => new
                {
                    RegistreeringID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpordialaID = table.Column<int>(nullable: false),
                   // SportlaseID = table.Column<int>(nullable: false), misseeon
                    SportlaneID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registreering", x => x.RegistreeringID);
                    table.ForeignKey(
                        name: "FK_Registreering_Spordiala_SpordialaID",
                        column: x => x.SpordialaID,
                        principalTable: "Spordiala",
                        principalColumn: "SpordialaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registreering_Sportlane_SportlaneID",
                        column: x => x.SportlaneID,
                        principalTable: "Sportlane",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registreering_SpordialaID",
                table: "Registreering",
                column: "SpordialaID");

            migrationBuilder.CreateIndex(
                name: "IX_Registreering_SportlaneID",
                table: "Registreering",
                column: "SportlaneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registreering");

            migrationBuilder.DropTable(
                name: "Spordiala");

            migrationBuilder.DropTable(
                name: "Sportlane");
        }
    }
}
