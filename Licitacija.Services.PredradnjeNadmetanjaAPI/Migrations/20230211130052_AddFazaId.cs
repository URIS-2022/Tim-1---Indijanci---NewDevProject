using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFazaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FazaId",
                table: "PredradnjeNadmetanja",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FazaId",
                table: "PredradnjeNadmetanja");
        }
    }
}
