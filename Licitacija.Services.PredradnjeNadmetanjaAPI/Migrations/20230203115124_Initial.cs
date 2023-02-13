using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PredradnjeNadmetanja",
                columns: table => new
                {
                    PredradnjeNadmetanjaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PredradnjeNadmetanjaNaziv = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredradnjeNadmetanja", x => x.PredradnjeNadmetanjaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PredradnjeNadmetanja_PredradnjeNadmetanjaNaziv",
                table: "PredradnjeNadmetanja",
                column: "PredradnjeNadmetanjaNaziv",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredradnjeNadmetanja");
        }
    }
}
