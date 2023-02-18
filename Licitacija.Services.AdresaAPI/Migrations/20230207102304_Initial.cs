using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.AdresaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrzavaNaziv = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaId);
                });

            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    AdresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Broj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostanskiBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrzavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.AdresaId);
                    table.ForeignKey(
                        name: "FK_Adresa_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresa_DrzavaId",
                table: "Adresa",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Drzava_DrzavaNaziv",
                table: "Drzava",
                column: "DrzavaNaziv",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresa");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
