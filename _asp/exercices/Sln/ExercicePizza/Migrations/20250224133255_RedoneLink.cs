using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExercicePizza.Migrations
{
    /// <inheritdoc />
    public partial class RedoneLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Margerita");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Hawaienne");
        }
    }
}
