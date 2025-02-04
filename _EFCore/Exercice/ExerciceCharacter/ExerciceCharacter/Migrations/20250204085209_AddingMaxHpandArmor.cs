using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciceCharacter.Migrations
{
    /// <inheritdoc />
    public partial class AddingMaxHpandArmor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxArmor",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxHP",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreation", "MaxArmor", "MaxHP" },
                values: new object[] { new DateTime(2025, 2, 4, 9, 52, 8, 866, DateTimeKind.Local).AddTicks(4621), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxArmor",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MaxHP",
                table: "Characters");

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2025, 2, 3, 16, 16, 28, 892, DateTimeKind.Local).AddTicks(2615));
        }
    }
}
