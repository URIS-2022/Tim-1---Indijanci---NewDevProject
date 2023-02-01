using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.KupacAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrojTel1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OstvarenPovrsina = table.Column<int>(type: "int", nullable: false),
                    ImaZabranu = table.Column<bool>(type: "bit", nullable: true),
                    DatumPocetkaZabrane = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzinaTrajanjaZabrane = table.Column<int>(type: "int", nullable: true),
                    DatumPrestankaZabrane = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrioritetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KupacId);
                    table.ForeignKey(
                        name: "FK_Kupac_Prioritet_PrioritetId",
                        column: x => x.PrioritetId,
                        principalTable: "Prioritet",
                        principalColumn: "PrioritetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FizickoLice",
                columns: table => new
                {
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FizickoLiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FizickoLiceIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FizickoLicePrezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FizickoLice", x => new { x.FizickoLiceId, x.KupacId });
                    table.ForeignKey(
                        name: "FK_FizickoLice_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "KupacId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PravnoLice",
                columns: table => new
                {
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PravnoLiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PravnoLiceNazv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaticniBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Faks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontaktOsobaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PravnoLice", x => new { x.PravnoLiceId, x.KupacId });
                    table.ForeignKey(
                        name: "FK_PravnoLice_KontaktOsoba_KontaktOsobaId",
                        column: x => x.KontaktOsobaId,
                        principalTable: "KontaktOsoba",
                        principalColumn: "KontaktOsobaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PravnoLice_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "KupacId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FizickoLice_KupacId",
                table: "FizickoLice",
                column: "KupacId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_PrioritetId",
                table: "Kupac",
                column: "PrioritetId");

            migrationBuilder.CreateIndex(
                name: "IX_PravnoLice_KontaktOsobaId",
                table: "PravnoLice",
                column: "KontaktOsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_PravnoLice_KupacId",
                table: "PravnoLice",
                column: "KupacId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FizickoLice");

            migrationBuilder.DropTable(
                name: "PravnoLice");

            migrationBuilder.DropTable(
                name: "Kupac");
        }
    }
}
