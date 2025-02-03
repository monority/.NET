using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciceCharacter.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2025, 2, 3, 16, 16, 28, 892, DateTimeKind.Local).AddTicks(2615));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2025, 2, 3, 16, 15, 39, 483, DateTimeKind.Local).AddTicks(3121));
        }
    }
}
