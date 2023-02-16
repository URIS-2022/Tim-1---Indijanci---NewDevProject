using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.KomisijaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licnost",
                columns: table => new
                {
                    LicnostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funkcija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licnost", x => x.LicnostId);
                });

            migrationBuilder.CreateTable(
                name: "TipKomisije",
                columns: table => new
                {
                    TipKomisijeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipKomisijeNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKomisije", x => x.TipKomisijeId);
                });

            migrationBuilder.CreateTable(
                name: "Komisija",
                columns: table => new
                {
                    KomisijaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipKomisijeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komisija", x => x.KomisijaId);
                    table.ForeignKey(
                        name: "FK_Komisija_TipKomisije_TipKomisijeId",
                        column: x => x.TipKomisijeId,
                        principalTable: "TipKomisije",
                        principalColumn: "TipKomisijeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LicnostKomisija",
                columns: table => new
                {
                    LicnostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KomisijaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicnostKomisija", x => new { x.LicnostId, x.KomisijaId });
                    table.ForeignKey(
                        name: "FK_LicnostKomisija_Komisija_KomisijaId",
                        column: x => x.KomisijaId,
                        principalTable: "Komisija",
                        principalColumn: "KomisijaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicnostKomisija_Licnost_LicnostId",
                        column: x => x.LicnostId,
                        principalTable: "Licnost",
                        principalColumn: "LicnostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komisija_TipKomisijeId",
                table: "Komisija",
                column: "TipKomisijeId");

            migrationBuilder.CreateIndex(
                name: "IX_LicnostKomisija_KomisijaId",
                table: "LicnostKomisija",
                column: "KomisijaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicnostKomisija");

            migrationBuilder.DropTable(
                name: "Komisija");

            migrationBuilder.DropTable(
                name: "Licnost");

            migrationBuilder.DropTable(
                name: "TipKomisije");
        }
    }
}
