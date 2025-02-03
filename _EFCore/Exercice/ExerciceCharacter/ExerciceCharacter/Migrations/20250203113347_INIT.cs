using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciceCharacter.Migrations
{
    /// <inheritdoc />
    public partial class INIT : Migration
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
                    Nickname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    HealthPoints = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    Armor = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    Damage = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KillCounts = table.Column<int>(type: "int", nullable: true),
                    CanGetKill = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Armor", "CanGetKill", "Damage", "DateCreation", "HealthPoints", "KillCounts", "Nickname" },
                values: new object[] { 1, 100, false, 1000, new DateTime(2025, 2, 3, 12, 33, 47, 614, DateTimeKind.Local).AddTicks(7513), 100, 0, "God" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
