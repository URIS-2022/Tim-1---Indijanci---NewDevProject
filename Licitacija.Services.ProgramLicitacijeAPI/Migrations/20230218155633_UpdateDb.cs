using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.ProgramLicitacijeAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Komisija",
                table: "Komisija");

            migrationBuilder.RenameTable(
                name: "Komisija",
                newName: "KreiranjeProgramaLicitacije");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KreiranjeProgramaLicitacije",
                table: "KreiranjeProgramaLicitacije",
                column: "ProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KreiranjeProgramaLicitacije",
                table: "KreiranjeProgramaLicitacije");

            migrationBuilder.RenameTable(
                name: "KreiranjeProgramaLicitacije",
                newName: "Komisija");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Komisija",
                table: "Komisija",
                column: "ProgramId");
        }
    }
}
