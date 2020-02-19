using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sport.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sportlane",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Perekonnanimi = table.Column<string>(maxLength: 50, nullable: false),
                    Eesnimi = table.Column<string>(maxLength: 50, nullable: false),
                    RegistreeringuKP = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sportlane", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Treener",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Perekonnanimi = table.Column<string>(maxLength: 50, nullable: false),
                    Eesnimi = table.Column<string>(maxLength: 50, nullable: false),
                    PalkamiseKP = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treener", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AsutuseAssignment",
                columns: table => new
                {
                    TreenerID = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsutuseAssignment", x => x.TreenerID);
                    table.ForeignKey(
                        name: "FK_AsutuseAssignment_Treener_TreenerID",
                        column: x => x.TreenerID,
                        principalTable: "Treener",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Osakond",
                columns: table => new
                {
                    OsakondID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nimi = table.Column<string>(maxLength: 50, nullable: true),
                    Eelarve = table.Column<decimal>(type: "money", nullable: false),
                    AlgusKP = table.Column<DateTime>(nullable: false),
                    TreenerID = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osakond", x => x.OsakondID);
                    table.ForeignKey(
                        name: "FK_Osakond_Treener_TreenerID",
                        column: x => x.TreenerID,
                        principalTable: "Treener",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spordiala",
                columns: table => new
                {
                    SpordialaID = table.Column<int>(nullable: false),
                    Nimi = table.Column<string>(maxLength: 50, nullable: true),
                    Tulemused = table.Column<int>(nullable: false),
                    OsakondID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spordiala", x => x.SpordialaID);
                    table.ForeignKey(
                        name: "FK_Spordiala_Osakond_OsakondID",
                        column: x => x.OsakondID,
                        principalTable: "Osakond",
                        principalColumn: "OsakondID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registreering",
                columns: table => new
                {
                    RegistreeringID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpordialaID = table.Column<int>(nullable: false),
                    SportlaneID = table.Column<int>(nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpordialaAssignment",
                columns: table => new
                {
                    TreenerID = table.Column<int>(nullable: false),
                    SpordialaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpordialaAssignment", x => new { x.SpordialaID, x.TreenerID });
                    table.ForeignKey(
                        name: "FK_SpordialaAssignment_Spordiala_SpordialaID",
                        column: x => x.SpordialaID,
                        principalTable: "Spordiala",
                        principalColumn: "SpordialaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpordialaAssignment_Treener_TreenerID",
                        column: x => x.TreenerID,
                        principalTable: "Treener",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Osakond_TreenerID",
                table: "Osakond",
                column: "TreenerID");

            migrationBuilder.CreateIndex(
                name: "IX_Registreering_SpordialaID",
                table: "Registreering",
                column: "SpordialaID");

            migrationBuilder.CreateIndex(
                name: "IX_Registreering_SportlaneID",
                table: "Registreering",
                column: "SportlaneID");

            migrationBuilder.CreateIndex(
                name: "IX_Spordiala_OsakondID",
                table: "Spordiala",
                column: "OsakondID");

            migrationBuilder.CreateIndex(
                name: "IX_SpordialaAssignment_TreenerID",
                table: "SpordialaAssignment",
                column: "TreenerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsutuseAssignment");

            migrationBuilder.DropTable(
                name: "Registreering");

            migrationBuilder.DropTable(
                name: "SpordialaAssignment");

            migrationBuilder.DropTable(
                name: "Sportlane");

            migrationBuilder.DropTable(
                name: "Spordiala");

            migrationBuilder.DropTable(
                name: "Osakond");

            migrationBuilder.DropTable(
                name: "Treener");
        }
    }
}
