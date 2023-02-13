using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.ZalbaAPI.Migrations
{
    /// <inheritdoc />
    public partial class createInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RadnjeNaOsnovuZalbe",
                columns: table => new
                {
                    RadnjaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RadnjaNaziv = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadnjeNaOsnovuZalbe", x => x.RadnjaId);
                });

            migrationBuilder.CreateTable(
                name: "StatusiZalbi",
                columns: table => new
                {
                    StatusZalbeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusZalbeNaziv = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusiZalbi", x => x.StatusZalbeId);
                });

            migrationBuilder.CreateTable(
                name: "TipoviZalbi",
                columns: table => new
                {
                    TipZalbeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipZalbeNaziv = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoviZalbi", x => x.TipZalbeId);
                });

            migrationBuilder.CreateTable(
                name: "Zalbe",
                columns: table => new
                {
                    ZalbaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumPodnosenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumResenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RazlogZalbe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obrazlozenje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojNadmetanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojOdluke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojResenja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusZalbeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipZalbeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RadnjaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FazaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalbe", x => x.ZalbaId);
                    table.ForeignKey(
                        name: "FK_Zalbe_RadnjeNaOsnovuZalbe_RadnjaeId",
                        column: x => x.RadnjaId,
                        principalTable: "RadnjeNaOsnovuZalbe",
                        principalColumn: "RadnjaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zalbe_StatusiZalbi_StatusZalbeId",
                        column: x => x.StatusZalbeId,
                        principalTable: "StatusiZalbi",
                        principalColumn: "StatusZalbeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zalbe_TipoviZalbi_TipZalbeId",
                        column: x => x.TipZalbeId,
                        principalTable: "TipoviZalbi",
                        principalColumn: "TipZalbeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RadnjeNaOsnovuZalbe_RadnjaNaziv",
                table: "RadnjeNaOsnovuZalbe",
                column: "RadnjaNaziv",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusiZalbi_StatusZalbeNaziv",
                table: "StatusiZalbi",
                column: "StatusZalbeNaziv",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoviZalbi_TipZalbeNaziv",
                table: "TipoviZalbi",
                column: "TipZalbeNaziv",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zalbe_RadnjaId",
                table: "Zalbe",
                column: "RadnjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalbe_StatusZalbeId",
                table: "Zalbe",
                column: "StatusZalbeId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalbe_TipZalbeId",
                table: "Zalbe",
                column: "TipZalbeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zalbe");

            migrationBuilder.DropTable(
                name: "RadnjeNaOsnovuZalbe");

            migrationBuilder.DropTable(
                name: "StatusiZalbi");

            migrationBuilder.DropTable(
                name: "TipoviZalbi");
        }
    }
}
