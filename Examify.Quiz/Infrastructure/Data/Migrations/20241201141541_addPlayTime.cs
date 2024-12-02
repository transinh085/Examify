using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examify.Quiz.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addPlayTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStart",
                table: "Quizzes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlayTime",
                table: "Quizzes",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStart",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "PlayTime",
                table: "Quizzes");
        }
    }
}
