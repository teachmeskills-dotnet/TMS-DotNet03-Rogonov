using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllQueez.DAL.Migrations
{
    public partial class GamesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "game");

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ThemeId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 127, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalSchema: "theme",
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_ThemeId",
                schema: "game",
                table: "Games",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserId",
                schema: "game",
                table: "Games",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games",
                schema: "game");
        }
    }
}
