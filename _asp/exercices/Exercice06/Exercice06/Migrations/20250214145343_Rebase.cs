using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice06.Migrations
{
    /// <inheritdoc />
    public partial class Rebase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Duration", "PictureUrl", "Status", "Title" },
                values: new object[] { 1L, "Lol", 120, "", 0, "Mols" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
