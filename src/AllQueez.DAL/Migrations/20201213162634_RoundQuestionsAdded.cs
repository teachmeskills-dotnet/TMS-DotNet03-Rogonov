using Microsoft.EntityFrameworkCore.Migrations;

namespace AllQueez.DAL.Migrations
{
    public partial class RoundQuestionsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Games_GameId",
                schema: "round",
                table: "Rounds");

            migrationBuilder.CreateTable(
                name: "RoundQuestions",
                schema: "round",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "question",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoundQuestions_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalSchema: "round",
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoundQuestions_QuestionId",
                schema: "round",
                table: "RoundQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundQuestions_RoundId",
                schema: "round",
                table: "RoundQuestions",
                column: "RoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Games_GameId",
                schema: "round",
                table: "Rounds",
                column: "GameId",
                principalSchema: "game",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Games_GameId",
                schema: "round",
                table: "Rounds");

            migrationBuilder.DropTable(
                name: "RoundQuestions",
                schema: "round");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Games_GameId",
                schema: "round",
                table: "Rounds",
                column: "GameId",
                principalSchema: "game",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
