﻿// <auto-generated />
using System;
using Examify.Result.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Examify.Result.Infrastructure.Data.Migrations
{
    [DbContext(typeof(QuizResultContext))]
    [Migration("20241203040025_addJoinQuizzes")]
    partial class addJoinQuizzes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Examify.Result.Entities.AnswerResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("boolean");

                    b.Property<Guid>("OptionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<Guid>("QuestionResultId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("QuestionResultId");

                    b.ToTable("AnswerResults");
                });

            modelBuilder.Entity("Examify.Result.Entities.JoinQuiz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("JoinQuizzes");
                });

            modelBuilder.Entity("Examify.Result.Entities.QuestionResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuizResultId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("SubmittedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TimeTaken")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("QuizResultId");

                    b.ToTable("QuestionResults");
                });

            modelBuilder.Entity("Examify.Result.Entities.QuizResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AttemptedNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CurrentQuestion")
                        .HasColumnType("integer");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("SubmittedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TimeTaken")
                        .HasColumnType("integer");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("QuizResults");
                });

            modelBuilder.Entity("Examify.Result.Entities.AnswerResult", b =>
                {
                    b.HasOne("Examify.Result.Entities.QuestionResult", null)
                        .WithMany("AnswerResults")
                        .HasForeignKey("QuestionResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examify.Result.Entities.QuestionResult", b =>
                {
                    b.HasOne("Examify.Result.Entities.QuizResult", null)
                        .WithMany("QuestionResults")
                        .HasForeignKey("QuizResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examify.Result.Entities.QuestionResult", b =>
                {
                    b.Navigation("AnswerResults");
                });

            modelBuilder.Entity("Examify.Result.Entities.QuizResult", b =>
                {
                    b.Navigation("QuestionResults");
                });
#pragma warning restore 612, 618
        }
    }
}