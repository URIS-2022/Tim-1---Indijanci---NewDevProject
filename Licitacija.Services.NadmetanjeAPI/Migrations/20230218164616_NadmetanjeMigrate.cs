using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.NadmetanjeAPI.Migrations
{
    /// <inheritdoc />
    public partial class NadmetanjeMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusNadmetanja",
                columns: table => new
                {
                    StatusNadmetanjaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusNadmetanjaNaziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusNadmetanja", x => x.StatusNadmetanjaId);
                });

            migrationBuilder.CreateTable(
                name: "Nadmetanje",
                columns: table => new
                {
                    NadmetanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicitacijaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KatOpstinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusNadmetanjaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FazaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VremePocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeKraja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CenaPoHektaru = table.Column<int>(type: "int", nullable: false),
                    Izuzeto = table.Column<bool>(type: "bit", nullable: false),
                    IzlicitiranaCena = table.Column<int>(type: "int", nullable: false),
                    PeriodZakupa = table.Column<int>(type: "int", nullable: false),
                    BrojUcesnika = table.Column<int>(type: "int", nullable: false),
                    VisinaDopuneDepozita = table.Column<int>(type: "int", nullable: false),
                    Krug = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nadmetanje", x => x.NadmetanjeId);
                    table.ForeignKey(
                        name: "FK_Nadmetanje_StatusNadmetanja_StatusNadmetanjaId",
                        column: x => x.StatusNadmetanjaId,
                        principalTable: "StatusNadmetanja",
                        principalColumn: "StatusNadmetanjaId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Javno",
                columns: table => new
                {
                    JavnoNadmetanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NadmetanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EtapaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Javno", x => x.JavnoNadmetanjeId);
                    table.ForeignKey(
                        name: "FK_Javno_Nadmetanje_NadmetanjeId",
                        column: x => x.NadmetanjeId,
                        principalTable: "Nadmetanje",
                        principalColumn: "NadmetanjeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtvaranjePonuda",
                columns: table => new
                {
                    OtvaranjePonudaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NadmetanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtvaranjePonuda", x => x.OtvaranjePonudaId);
                    table.ForeignKey(
                        name: "FK_OtvaranjePonuda_Nadmetanje_NadmetanjeId",
                        column: x => x.NadmetanjeId,
                        principalTable: "Nadmetanje",
                        principalColumn: "NadmetanjeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Javno_NadmetanjeId",
                table: "Javno",
                column: "NadmetanjeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nadmetanje_StatusNadmetanjaId",
                table: "Nadmetanje",
                column: "StatusNadmetanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_OtvaranjePonuda_NadmetanjeId",
                table: "OtvaranjePonuda",
                column: "NadmetanjeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Javno");

            migrationBuilder.DropTable(
                name: "OtvaranjePonuda");

            migrationBuilder.DropTable(
                name: "Nadmetanje");

            migrationBuilder.DropTable(
                name: "StatusNadmetanja");
        }
    }
}
