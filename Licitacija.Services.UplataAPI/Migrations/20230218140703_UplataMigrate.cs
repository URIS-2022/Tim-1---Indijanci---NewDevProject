using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.UplataAPI.Migrations
{
    /// <inheritdoc />
    public partial class UplataMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kurs",
                columns: table => new
                {
                    KursId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumKursa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valuta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vrednost = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurs", x => x.KursId);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    UplataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PozivNaBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iznos = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SvrhaUplate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumUplate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KursId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.UplataId);
                    table.ForeignKey(
                        name: "FK_Uplata_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurs",
                        principalColumn: "KursId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_KursId",
                table: "Uplata",
                column: "KursId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "Kurs");
        }
    }
}
