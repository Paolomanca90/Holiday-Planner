using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holiday.Data.Migrations
{
    public partial class udpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cognome",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Ore",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Scelta",
                columns: table => new
                {
                    IdScelta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoScelta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scelta", x => x.IdScelta);
                });

            migrationBuilder.CreateTable(
                name: "Richiesta",
                columns: table => new
                {
                    IdRichiesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRichiesta = table.Column<int>(type: "int", nullable: false),
                    InizioRichiesta = table.Column<DateTime>(type: "datetime", nullable: false),
                    FineRichiesta = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Richiesta", x => x.IdRichiesta);
                    table.ForeignKey(
                        name: "FK_Richiesta_AspNetUsers",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Richiesta_Scelta",
                        column: x => x.TipoRichiesta,
                        principalTable: "Scelta",
                        principalColumn: "IdScelta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Richiesta_TipoRichiesta",
                table: "Richiesta",
                column: "TipoRichiesta");

            migrationBuilder.CreateIndex(
                name: "IX_Richiesta_UserID",
                table: "Richiesta",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Richiesta");

            migrationBuilder.DropTable(
                name: "Scelta");

            migrationBuilder.DropColumn(
                name: "Cognome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ore",
                table: "AspNetUsers");
        }
    }
}
