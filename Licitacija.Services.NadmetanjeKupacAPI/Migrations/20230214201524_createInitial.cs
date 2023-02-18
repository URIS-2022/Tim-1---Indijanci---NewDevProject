using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.NadmetanjeKupacAPI.Migrations
{
    /// <inheritdoc />
    public partial class createInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OvlascenoLice",
                columns: table => new
                {
                    OvlascenoLiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojPasosa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvlascenoLice", x => x.OvlascenoLiceId);
                });

            migrationBuilder.CreateTable(
                name: "NadmetanjeKupac",
                columns: table => new
                {
                    NadmetanjeKupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OvlascenoLiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NadmetanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NadmetanjeKupac", x => x.NadmetanjeKupacId);
                    table.ForeignKey(
                        name: "FK_NadmetanjeKupac_OvlascenoLice_OvlascenoLiceId",
                        column: x => x.OvlascenoLiceId,
                        principalTable: "OvlascenoLice",
                        principalColumn: "OvlascenoLiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NadmetanjeKupac_OvlascenoLiceId",
                table: "NadmetanjeKupac",
                column: "OvlascenoLiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NadmetanjeKupac");

            migrationBuilder.DropTable(
                name: "OvlascenoLice");
        }
    }
}
