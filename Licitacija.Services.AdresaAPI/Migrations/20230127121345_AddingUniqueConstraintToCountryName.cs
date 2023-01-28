using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.AdresaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingUniqueConstraintToCountryName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DrzavaNaziv",
                table: "Drzava",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Drzava_DrzavaNaziv",
                table: "Drzava",
                column: "DrzavaNaziv",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Drzava_DrzavaNaziv",
                table: "Drzava");

            migrationBuilder.AlterColumn<string>(
                name: "DrzavaNaziv",
                table: "Drzava",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
