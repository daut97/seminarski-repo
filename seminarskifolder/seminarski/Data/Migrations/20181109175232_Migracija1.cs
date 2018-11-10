using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace seminarski.Data.Migrations
{
    public partial class Migracija1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    ProizvodjacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    DrzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.ProizvodjacID);
                    table.ForeignKey(
                        name: "FK_Proizvodjac_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auto",
                columns: table => new
                {
                    AutoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProizvodjacID = table.Column<int>(nullable: false),
                    Boja = table.Column<string>(nullable: true),
                    Godiste = table.Column<string>(nullable: true),
                    Novo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auto", x => x.AutoID);
                    table.ForeignKey(
                        name: "FK_Auto_Proizvodjac_ProizvodjacID",
                        column: x => x.ProizvodjacID,
                        principalTable: "Proizvodjac",
                        principalColumn: "ProizvodjacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auto_ProizvodjacID",
                table: "Auto",
                column: "ProizvodjacID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodjac_DrzavaID",
                table: "Proizvodjac",
                column: "DrzavaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auto");

            migrationBuilder.DropTable(
                name: "Proizvodjac");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
