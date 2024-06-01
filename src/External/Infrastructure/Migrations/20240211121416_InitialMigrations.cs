using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contestants",
                columns: table => new
                {
                    ContestantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contestants", x => x.ContestantId);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<float>(type: "real", nullable: false),
                    DailyLimit = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.DisciplineId);
                });

            migrationBuilder.CreateTable(
                name: "Scoreboards",
                columns: table => new
                {
                    ScoreboardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContestantId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    TimeDisciplineStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeDisciplineFinished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDisciplinePlayed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scoreboards", x => x.ScoreboardId);
                });

            migrationBuilder.InsertData(
                table: "Contestants",
                columns: new[] { "ContestantId", "Age", "Email", "FirstName", "Image", "IsAdmin", "LastName", "Nickname" },
                values: new object[,]
                {
                    { 1, 25, null, "J", null, true, "C", "Caksa" },
                    { 2, 23, null, "G", null, true, "P", "Gypsy king" },
                    { 3, 26, null, "S", null, true, "T", "Srdzan" },
                    { 4, 23, null, "V", null, true, "T", "Csni" }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "DisciplineId", "DailyLimit", "Description", "Image", "Name", "Points" },
                values: new object[,]
                {
                    { 10, 1, "3UP description", null, "3UP", 1.5f },
                    { 11, 1, "Football Dice description", null, "Footbal Dice", 1.25f },
                    { 12, 4, "Uno description", null, "Uno", 1f },
                    { 13, 1, "Darts description", null, "Darts", 1f }
                });

            migrationBuilder.InsertData(
                table: "Scoreboards",
                columns: new[] { "ScoreboardId", "ContestantId", "DateDisciplinePlayed", "DisciplineId", "TimeDisciplineFinished", "TimeDisciplineStarted" },
                values: new object[] { 5, 20, 20240108, 10, new DateTime(2024, 2, 11, 13, 24, 14, 670, DateTimeKind.Local).AddTicks(5823), new DateTime(2024, 2, 11, 13, 14, 14, 670, DateTimeKind.Local).AddTicks(5779) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contestants");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Scoreboards");
        }
    }
}
