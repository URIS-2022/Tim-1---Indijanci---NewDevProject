using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.KupacAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddONdeleteSetNull2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kupac_Prioritet_PrioritetId",
                table: "Kupac");

            migrationBuilder.AddForeignKey(
                name: "FK_Kupac_Prioritet_PrioritetId",
                table: "Kupac",
                column: "PrioritetId",
                principalTable: "Prioritet",
                principalColumn: "PrioritetId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kupac_Prioritet_PrioritetId",
                table: "Kupac");

            migrationBuilder.AddForeignKey(
                name: "FK_Kupac_Prioritet_PrioritetId",
                table: "Kupac",
                column: "PrioritetId",
                principalTable: "Prioritet",
                principalColumn: "PrioritetId");
        }
    }
}
