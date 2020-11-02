using Microsoft.EntityFrameworkCore.Migrations;

namespace AllQueez.DAL.Migrations
{
    public partial class QuestionPathPropertyRequiredFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoundQuestions",
                schema: "roundQuestion");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                schema: "question",
                table: "Questions",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "roundQuestion");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                schema: "question",
                table: "Questions",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RoundQuestions",
                schema: "roundQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    RoundId = table.Column<int>(type: "int", nullable: false)
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
    }
}
