using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.ZavrsneRadnjeAPI.Migrations
{
    /// <inheritdoc />
    public partial class createInitials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZavrsneRadnje",
                columns: table => new
                {
                    ZavrsnaRadnjaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZavrsnaRadnjaNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FazaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZavrsneRadnje", x => x.ZavrsnaRadnjaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZavrsneRadnje");
        }
    }
}
