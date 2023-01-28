using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.AdresaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ListAdresaInDrzava : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresa_Drzava_DrzavaId",
                table: "Adresa");

            migrationBuilder.AlterColumn<Guid>(
                name: "DrzavaId",
                table: "Adresa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<Guid>(
                name: "DrzavaId",
                table: "Adresa",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresa_Drzava_DrzavaId",
                table: "Adresa",
                column: "DrzavaId",
                principalTable: "Drzava",
                principalColumn: "DrzavaId");
        }
    }
}
