using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciceCharacter.Migrations
{
    /// <inheritdoc />
    public partial class Reset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthPoints = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    Armor = table.Column<int>(type: "int", nullable: true),
                    Damage = table.Column<int>(type: "int", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KillCounts = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Armor", "Damage", "DateCreation", "HealthPoints", "KillCounts", "Nickname" },
                values: new object[] { 1, 100, 1000, new DateTime(2025, 2, 3, 16, 15, 39, 483, DateTimeKind.Local).AddTicks(3121), 100, 0, "God" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
