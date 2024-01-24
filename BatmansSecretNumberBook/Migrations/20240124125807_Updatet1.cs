using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatmansSecretNumberBook.Migrations
{
    /// <inheritdoc />
    public partial class Updatet1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KontaktPrivat");

            migrationBuilder.DropColumn(
                name: "Attribute",
                table: "Kontakte");

            migrationBuilder.CreateTable(
                name: "KontaktPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Lieblingsheld = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontaktPrivate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KontaktPrivate_Kontakte_Id",
                        column: x => x.Id,
                        principalTable: "Kontakte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KontaktPrivate");

            migrationBuilder.AddColumn<string>(
                name: "Attribute",
                table: "Kontakte",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "KontaktPrivat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Lieblingsheld = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontaktPrivat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KontaktPrivat_Kontakte_Id",
                        column: x => x.Id,
                        principalTable: "Kontakte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
