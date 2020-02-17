using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sport.Migrations
{
    public partial class ComplexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registreering_Sportlane_SportlaneID",
                table: "Registreering");

            migrationBuilder.DropColumn(
                name: "SportlaseID",
                table: "Registreering");

            migrationBuilder.AlterColumn<string>(
                name: "Perekonnanimi",
                table: "Sportlane",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nimi",
                table: "Spordiala",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

          /* migrationBuilder.AddColumn<int>(
                name: "OsakondID",
                table: "Spordiala",
                nullable: false,
                defaultValue: 0);
    */

            migrationBuilder.AlterColumn<int>(
                name: "SportlaneID",
                table: "Registreering",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                    TreenerID = table.Column<int>(nullable: true)
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

            migrationBuilder.Sql("INSERT INTO dbo.Osakond (Nimi, Eelarve, AlgusKP) VALUES ('Temp', 0.00, GETDATE())");
            // Default value for FK points to department created above, with
            // defaultValue changed to 1 in following AddColumn statement.

            migrationBuilder.AddColumn<int>(
                name: "OsakondID",
                table: "Spordiala",
                nullable: false,
                defaultValue: 1);

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
                name: "IX_Spordiala_OsakondID",
                table: "Spordiala",
                column: "OsakondID");

            migrationBuilder.CreateIndex(
                name: "IX_Osakond_TreenerID",
                table: "Osakond",
                column: "TreenerID");

            migrationBuilder.CreateIndex(
                name: "IX_SpordialaAssignment_TreenerID",
                table: "SpordialaAssignment",
                column: "TreenerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Registreering_Sportlane_SportlaneID",
                table: "Registreering",
                column: "SportlaneID",
                principalTable: "Sportlane",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spordiala_Osakond_OsakondID",
                table: "Spordiala",
                column: "OsakondID",
                principalTable: "Osakond",
                principalColumn: "OsakondID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registreering_Sportlane_SportlaneID",
                table: "Registreering");

            migrationBuilder.DropForeignKey(
                name: "FK_Spordiala_Osakond_OsakondID",
                table: "Spordiala");

            migrationBuilder.DropTable(
                name: "AsutuseAssignment");

            migrationBuilder.DropTable(
                name: "Osakond");

            migrationBuilder.DropTable(
                name: "SpordialaAssignment");

            migrationBuilder.DropTable(
                name: "Treener");

            migrationBuilder.DropIndex(
                name: "IX_Spordiala_OsakondID",
                table: "Spordiala");

            migrationBuilder.DropColumn(
                name: "OsakondID",
                table: "Spordiala");

            migrationBuilder.AlterColumn<string>(
                name: "Perekonnanimi",
                table: "Sportlane",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nimi",
                table: "Spordiala",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SportlaneID",
                table: "Registreering",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SportlaseID",
                table: "Registreering",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Registreering_Sportlane_SportlaneID",
                table: "Registreering",
                column: "SportlaneID",
                principalTable: "Sportlane",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
