using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitacija.Services.ParcelaAPI.Migrations
{
    /// <inheritdoc />
    public partial class createInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KatastarskeOpstine",
                columns: table => new
                {
                    KatOpstinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KatOpstinaNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KatastarskeOpstine", x => x.KatOpstinaId);
                });

            migrationBuilder.CreateTable(
                name: "Klase",
                columns: table => new
                {
                    KlasaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KlasaNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klase", x => x.KlasaId);
                });

            migrationBuilder.CreateTable(
                name: "Kulture",
                columns: table => new
                {
                    KulturaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KulturaNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kulture", x => x.KulturaId);
                });

            migrationBuilder.CreateTable(
                name: "ObliciSvojina",
                columns: table => new
                {
                    OblikSvojineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OblikSvojineNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObliciSvojina", x => x.OblikSvojineId);
                });

            migrationBuilder.CreateTable(
                name: "Obradivosti",
                columns: table => new
                {
                    ObradivostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObradivostNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obradivosti", x => x.ObradivostId);
                });

            migrationBuilder.CreateTable(
                name: "Odvodnjavanja",
                columns: table => new
                {
                    OdvodnjavanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdvNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odvodnjavanja", x => x.OdvodnjavanjeId);
                });

            migrationBuilder.CreateTable(
                name: "ZasticeneZone",
                columns: table => new
                {
                    ZZonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZZonaNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZasticeneZone", x => x.ZZonaId);
                });

            migrationBuilder.CreateTable(
                name: "Parcele",
                columns: table => new
                {
                    ParcelaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Povrsina = table.Column<int>(type: "int", nullable: false),
                    BrojParcele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojListaNepokretnosti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KulturaStvStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KlasaStvStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObradivostStvStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZZonaStvStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdvodnjavanjeStvStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdvodnjavanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KulturaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KlasaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObradivostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OblikSvojineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KatOpstinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcele", x => x.ParcelaId);
                    table.ForeignKey(
                        name: "FK_Parcele_KatastarskeOpstine_KatastarskaOpstinaId",
                        column: x => x.KatOpstinaId,
                        principalTable: "KatastarskeOpstine",
                        principalColumn: "KatOpstinaId");
                    table.ForeignKey(
                        name: "FK_Parcele_Klase_KlasaId",
                        column: x => x.KlasaId,
                        principalTable: "Klase",
                        principalColumn: "KlasaId");
                    table.ForeignKey(
                        name: "FK_Parcele_Kulture_KulturaId",
                        column: x => x.KulturaId,
                        principalTable: "Kulture",
                        principalColumn: "KulturaId");
                    table.ForeignKey(
                        name: "FK_Parcele_ObliciSvojina_OblikSvojineId",
                        column: x => x.OblikSvojineId,
                        principalTable: "ObliciSvojina",
                        principalColumn: "OblikSvojineId");
                    table.ForeignKey(
                        name: "FK_Parcele_Obradivosti_ObradivostId",
                        column: x => x.ObradivostId,
                        principalTable: "Obradivosti",
                        principalColumn: "ObradivostId");
                    table.ForeignKey(
                        name: "FK_Parcele_Odvodnjavanja_OdvodnjavanjeId",
                        column: x => x.OdvodnjavanjeId,
                        principalTable: "Odvodnjavanja",
                        principalColumn: "OdvodnjavanjeId");
                });

            migrationBuilder.CreateTable(
                name: "DeloviParcele",
                columns: table => new
                {
                    DeoParceleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PovrsinaDelaParcele = table.Column<int>(type: "int", nullable: false),
                    ParcelaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EtapaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OtvaranjePonudaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeloviParcele", x => x.DeoParceleId);
                    table.ForeignKey(
                        name: "FK_DeloviParcele_Parcele_ParcelaId",
                        column: x => x.ParcelaId,
                        principalTable: "Parcele",
                        principalColumn: "ParcelaId");
                });

            migrationBuilder.CreateTable(
                name: "Povrsine",
                columns: table => new
                {
                    PovrsinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PovrsinaZZone = table.Column<int>(type: "int", nullable: false),
                    ParcelaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZZonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Povrsine", x => x.PovrsinaId);
                    table.ForeignKey(
                        name: "FK_Povrsine_Parcele_ParcelaId",
                        column: x => x.ParcelaId,
                        principalTable: "Parcele",
                        principalColumn: "ParcelaId");
                    table.ForeignKey(
                        name: "FK_Povrsine_ZasticeneZone_ZZonaId",
                        column: x => x.ZZonaId,
                        principalTable: "ZasticeneZone",
                        principalColumn: "ZZonaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeloviParcele_ParcelaId",
                table: "DeloviParcele",
                column: "ParcelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcele_KatOpstinaId",
                table: "Parcele",
                column: "KatOpstinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcele_KlasaId",
                table: "Parcele",
                column: "KlasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcele_KulturaId",
                table: "Parcele",
                column: "KulturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcele_OblikSvojineId",
                table: "Parcele",
                column: "OblikSvojineId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcele_ObradivostId",
                table: "Parcele",
                column: "ObradivostId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcele_OdvodnjavanjeId",
                table: "Parcele",
                column: "OdvodnjavanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Povrsine_ParcelaId",
                table: "Povrsine",
                column: "ParcelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Povrsine_ZZonaId",
                table: "Povrsine",
                column: "ZZonaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeloviParcele");

            migrationBuilder.DropTable(
                name: "Povrsine");

            migrationBuilder.DropTable(
                name: "Parcele");

            migrationBuilder.DropTable(
                name: "ZasticeneZone");

            migrationBuilder.DropTable(
                name: "KatastarskeOpstine");

            migrationBuilder.DropTable(
                name: "Klase");

            migrationBuilder.DropTable(
                name: "Kulture");

            migrationBuilder.DropTable(
                name: "ObliciSvojina");

            migrationBuilder.DropTable(
                name: "Obradivosti");

            migrationBuilder.DropTable(
                name: "Odvodnjavanja");
        }
    }
}
