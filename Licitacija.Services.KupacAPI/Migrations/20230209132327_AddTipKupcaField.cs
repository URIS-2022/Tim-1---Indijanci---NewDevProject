using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.KupacAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTipKupcaField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipKupca",
                table: "Kupac",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipKupca",
                table: "Kupac");
        }
    }
}
