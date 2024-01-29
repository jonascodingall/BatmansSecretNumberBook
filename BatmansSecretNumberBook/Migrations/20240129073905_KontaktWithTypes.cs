using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatmansSecretNumberBook.Migrations
{
    /// <inheritdoc />
    public partial class KontaktWithTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontakt_Personen_PersonId",
                table: "Kontakt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kontakt",
                table: "Kontakt");

            migrationBuilder.RenameTable(
                name: "Kontakt",
                newName: "Kontakte");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Kontakte",
                newName: "KontaktType");

            migrationBuilder.RenameIndex(
                name: "IX_Kontakt_PersonId",
                table: "Kontakte",
                newName: "IX_Kontakte_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kontakte",
                table: "Kontakte",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kontakte_Personen_PersonId",
                table: "Kontakte",
                column: "PersonId",
                principalTable: "Personen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontakte_Personen_PersonId",
                table: "Kontakte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kontakte",
                table: "Kontakte");

            migrationBuilder.RenameTable(
                name: "Kontakte",
                newName: "Kontakt");

            migrationBuilder.RenameColumn(
                name: "KontaktType",
                table: "Kontakt",
                newName: "Discriminator");

            migrationBuilder.RenameIndex(
                name: "IX_Kontakte_PersonId",
                table: "Kontakt",
                newName: "IX_Kontakt_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kontakt",
                table: "Kontakt",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kontakt_Personen_PersonId",
                table: "Kontakt",
                column: "PersonId",
                principalTable: "Personen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
