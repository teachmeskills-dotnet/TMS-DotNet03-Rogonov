using Microsoft.EntityFrameworkCore.Migrations;

namespace AllQueez.DAL.Migrations
{
    public partial class RoundQuestionsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "roundQuestion");

            migrationBuilder.CreateTable(
                name: "RoundQuestions",
                schema: "roundQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoundQuestions_QuestionId",
                schema: "roundQuestion",
                table: "RoundQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundQuestions_RoundId",
                schema: "roundQuestion",
                table: "RoundQuestions",
                column: "RoundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoundQuestions",
                schema: "roundQuestion");
        }
    }
}
