using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tanulok.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SzervezetiEgysegek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SZeNev = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SzervezetiEgysegek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tagozatok",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TagozatNev = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tagozatok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tanulok",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NEPTUNKod = table.Column<string>(maxLength: 6, nullable: false),
                    Nev = table.Column<string>(maxLength: 150, nullable: false),
                    SzervezetiEgysegId = table.Column<int>(nullable: false),
                    AktualFelev = table.Column<string>(maxLength: 100, nullable: true),
                    TagozatId = table.Column<int>(nullable: false),
                    FelvetelDatuma = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanulok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tanulok_SzervezetiEgysegek_SzervezetiEgysegId",
                        column: x => x.SzervezetiEgysegId,
                        principalTable: "SzervezetiEgysegek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tanulok_Tagozatok_TagozatId",
                        column: x => x.TagozatId,
                        principalTable: "Tagozatok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SzervezetiEgysegek",
                columns: new[] { "Id", "SZeNev" },
                values: new object[,]
                {
                    { 1, "Műszaki és Informatikai Kar" },
                    { 2, "Gazdaságtudományi Kar" },
                    { 3, "Kertészeti és Vidékfejlesztési Kar" }
                });

            migrationBuilder.InsertData(
                table: "Tagozatok",
                columns: new[] { "Id", "TagozatNev" },
                values: new object[,]
                {
                    { 1, "Nappali" },
                    { 2, "Levelező" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SzervezetiEgysegek_SZeNev",
                table: "SzervezetiEgysegek",
                column: "SZeNev",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tagozatok_TagozatNev",
                table: "Tagozatok",
                column: "TagozatNev",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tanulok_NEPTUNKod",
                table: "Tanulok",
                column: "NEPTUNKod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tanulok_SzervezetiEgysegId",
                table: "Tanulok",
                column: "SzervezetiEgysegId");

            migrationBuilder.CreateIndex(
                name: "IX_Tanulok_TagozatId",
                table: "Tanulok",
                column: "TagozatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tanulok");

            migrationBuilder.DropTable(
                name: "SzervezetiEgysegek");

            migrationBuilder.DropTable(
                name: "Tagozatok");
        }
    }
}
