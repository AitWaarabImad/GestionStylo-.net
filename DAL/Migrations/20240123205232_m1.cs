using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marques",
                columns: table => new
                {
                    Nom = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marques", x => x.Nom);
                });

            migrationBuilder.CreateTable(
                name: "types",
                columns: table => new
                {
                    Nom = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types", x => x.Nom);
                });

            migrationBuilder.CreateTable(
                name: "stylos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomMarque = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomType = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stylos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stylos_marques_NomMarque",
                        column: x => x.NomMarque,
                        principalTable: "marques",
                        principalColumn: "Nom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stylos_types_NomType",
                        column: x => x.NomType,
                        principalTable: "types",
                        principalColumn: "Nom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stylos_NomMarque",
                table: "stylos",
                column: "NomMarque");

            migrationBuilder.CreateIndex(
                name: "IX_stylos_NomType",
                table: "stylos",
                column: "NomType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stylos");

            migrationBuilder.DropTable(
                name: "marques");

            migrationBuilder.DropTable(
                name: "types");
        }
    }
}
