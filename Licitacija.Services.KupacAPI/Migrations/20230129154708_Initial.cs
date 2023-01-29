using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.KupacAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KontaktOsoba",
                columns: table => new
                {
                    KontaktOsobaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KontaktOsobaIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontaktOsobaPrezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funkcija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontaktOsoba", x => x.KontaktOsobaId);
                });

            migrationBuilder.CreateTable(
                name: "Prioritet",
                columns: table => new
                {
                    PrioritetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrioritetNaziv = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioritet", x => x.PrioritetId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prioritet_PrioritetNaziv",
                table: "Prioritet",
                column: "PrioritetNaziv",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KontaktOsoba");

            migrationBuilder.DropTable(
                name: "Prioritet");
        }
    }
}
