using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dem01.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "PublicationDate", "TItle" },
                values: new object[] { 1, "Arthur DENNETIERE", "La meilleure recette de crêpes", new DateTime(2025, 2, 3, 11, 41, 4, 813, DateTimeKind.Local).AddTicks(6248), "La recette des crêpes" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
