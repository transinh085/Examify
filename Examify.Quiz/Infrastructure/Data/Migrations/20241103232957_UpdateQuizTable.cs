using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examify.Quiz.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuizTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Quizzes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Quizzes");
        }
    }
}
