using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.DokumentAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusDokumenta",
                columns: table => new
                {
                    StatusDokumentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusDokumentaNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusDokumenta", x => x.StatusDokumentaId);
                });

            migrationBuilder.CreateTable(
                name: "TipGarancije",
                columns: table => new
                {
                    TipGarancijeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipGarancijeNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipGarancije", x => x.TipGarancijeId);
                });

            migrationBuilder.CreateTable(
                name: "Dokument",
                columns: table => new
                {
                    DokumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZavodniBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPotpisivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDonosenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sablon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDokumentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.DokumentId);
                    table.ForeignKey(
                        name: "FK_Dokument_StatusDokumenta_StatusDokumentaId",
                        column: x => x.StatusDokumentaId,
                        principalTable: "StatusDokumenta",
                        principalColumn: "StatusDokumentaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EksterniDokument",
                columns: table => new
                {
                    EksterniDokumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DokumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ustanova = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EksterniDokument", x => x.EksterniDokumentId);
                    table.ForeignKey(
                        name: "FK_EksterniDokument_Dokument_DokumentId",
                        column: x => x.DokumentId,
                        principalTable: "Dokument",
                        principalColumn: "DokumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UgovorOZakupu",
                columns: table => new
                {
                    UgovorOZakupuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DokumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RokDospeca = table.Column<int>(type: "int", nullable: false),
                    RokVracanjaZemljista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MestoPotpisivanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipGarancijeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicnostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UplataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UgovorOZakupu", x => x.UgovorOZakupuId);
                    table.ForeignKey(
                        name: "FK_UgovorOZakupu_Dokument_DokumentId",
                        column: x => x.DokumentId,
                        principalTable: "Dokument",
                        principalColumn: "DokumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UgovorOZakupu_TipGarancije_TipGarancijeId",
                        column: x => x.TipGarancijeId,
                        principalTable: "TipGarancije",
                        principalColumn: "TipGarancijeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_StatusDokumentaId",
                table: "Dokument",
                column: "StatusDokumentaId");

            migrationBuilder.CreateIndex(
                name: "IX_EksterniDokument_DokumentId",
                table: "EksterniDokument",
                column: "DokumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UgovorOZakupu_DokumentId",
                table: "UgovorOZakupu",
                column: "DokumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UgovorOZakupu_TipGarancijeId",
                table: "UgovorOZakupu",
                column: "TipGarancijeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EksterniDokument");

            migrationBuilder.DropTable(
                name: "UgovorOZakupu");

            migrationBuilder.DropTable(
                name: "Dokument");

            migrationBuilder.DropTable(
                name: "TipGarancije");

            migrationBuilder.DropTable(
                name: "StatusDokumenta");
        }
    }
}
