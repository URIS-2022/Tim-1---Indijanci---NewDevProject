using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.KupacAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForeignKeyToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kupac_Prioritet_PrioritetId",
                table: "Kupac");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrioritetId",
                table: "Kupac",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Kupac_Prioritet_PrioritetId",
                table: "Kupac",
                column: "PrioritetId",
                principalTable: "Prioritet",
                principalColumn: "PrioritetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kupac_Prioritet_PrioritetId",
                table: "Kupac");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrioritetId",
                table: "Kupac",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kupac_Prioritet_PrioritetId",
                table: "Kupac",
                column: "PrioritetId",
                principalTable: "Prioritet",
                principalColumn: "PrioritetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
