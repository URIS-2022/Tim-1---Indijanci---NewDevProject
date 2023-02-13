using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.LicitacijaAPI.Migrations
{
    /// <inheritdoc />
    public partial class createInitials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licitacija",
                columns: table => new
                {
                    LicitacijaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Broj = table.Column<int>(type: "int", nullable: false),
                    Godina = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ogranicenje = table.Column<int>(type: "int", nullable: false),
                    KorakCene = table.Column<int>(type: "int", nullable: false),
                    RokZaPrijave = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licitacija", x => x.LicitacijaId);
                });

            migrationBuilder.CreateTable(
                name: "FazaLicitacije",
                columns: table => new
                {
                    FazaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FazaNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicitacijaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FazaLicitacije", x => x.FazaId);
                    table.ForeignKey(
                        name: "FK_FazaLicitacije_Licitacija_LicitacijaId",
                        column: x => x.LicitacijaId,
                        principalTable: "Licitacija",
                        principalColumn: "LicitacijaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FazaLicitacije_LicitacijaId",
                table: "FazaLicitacije",
                column: "LicitacijaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FazaLicitacije");

            migrationBuilder.DropTable(
                name: "Licitacija");
        }
    }
}
