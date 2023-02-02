using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.KupacAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddJsonIgnoreToKOsoba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PravnoLice_KontaktOsoba_KontaktOsobaId",
                table: "PravnoLice");

            migrationBuilder.AlterColumn<Guid>(
                name: "KontaktOsobaId",
                table: "PravnoLice",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PravnoLice_KontaktOsoba_KontaktOsobaId",
                table: "PravnoLice",
                column: "KontaktOsobaId",
                principalTable: "KontaktOsoba",
                principalColumn: "KontaktOsobaId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PravnoLice_KontaktOsoba_KontaktOsobaId",
                table: "PravnoLice");

            migrationBuilder.AlterColumn<Guid>(
                name: "KontaktOsobaId",
                table: "PravnoLice",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PravnoLice_KontaktOsoba_KontaktOsobaId",
                table: "PravnoLice",
                column: "KontaktOsobaId",
                principalTable: "KontaktOsoba",
                principalColumn: "KontaktOsobaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
