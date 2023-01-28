using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.AdresaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDrzavaObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostanskiBroj",
                table: "Adresa",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.CreateIndex(
                name: "IX_Adresa_DrzavaId",
                table: "Adresa",
                column: "DrzavaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresa_Drzava_DrzavaId",
                table: "Adresa",
                column: "DrzavaId",
                principalTable: "Drzava",
                principalColumn: "DrzavaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresa_Drzava_DrzavaId",
                table: "Adresa");

            migrationBuilder.DropIndex(
                name: "IX_Adresa_DrzavaId",
                table: "Adresa");

            migrationBuilder.AlterColumn<string>(
                name: "PostanskiBroj",
                table: "Adresa",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);
        }
    }
}
