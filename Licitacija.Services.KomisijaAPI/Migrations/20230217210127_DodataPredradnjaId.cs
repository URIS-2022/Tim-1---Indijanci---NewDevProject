using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.KomisijaAPI.Migrations
{
    /// <inheritdoc />
    public partial class DodataPredradnjaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PredradnjaNadmetanjaId",
                table: "Komisija",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PredradnjaNadmetanjaId",
                table: "Komisija");
        }
    }
}
