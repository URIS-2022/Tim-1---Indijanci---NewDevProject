using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.KupacAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToGeneralizationKupac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PravnoLice",
                table: "PravnoLice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FizickoLice",
                table: "FizickoLice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PravnoLice",
                table: "PravnoLice",
                column: "PravnoLiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FizickoLice",
                table: "FizickoLice",
                column: "FizickoLiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PravnoLice",
                table: "PravnoLice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FizickoLice",
                table: "FizickoLice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PravnoLice",
                table: "PravnoLice",
                columns: new[] { "PravnoLiceId", "KupacId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FizickoLice",
                table: "FizickoLice",
                columns: new[] { "FizickoLiceId", "KupacId" });
        }
    }
}
