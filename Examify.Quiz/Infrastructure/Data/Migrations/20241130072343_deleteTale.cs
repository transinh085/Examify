using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examify.Quiz.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class deleteTale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizSetting");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Quizzes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Quizzes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "RandomOptions",
                table: "Quizzes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RandomQuestions",
                table: "Quizzes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Quizzes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "RandomOptions",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "RandomQuestions",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Quizzes");

            migrationBuilder.CreateTable(
                name: "QuizSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuizId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RandomOptions = table.Column<bool>(type: "boolean", nullable: false),
                    RandomQuestions = table.Column<bool>(type: "boolean", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizSetting_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizSetting_QuizId",
                table: "QuizSetting",
                column: "QuizId",
                unique: true);
        }
    }
}
