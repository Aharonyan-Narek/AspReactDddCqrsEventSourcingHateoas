﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using YngStrs.PersonalityTests.Api.Persistence.EntityFramework;

namespace YngStrs.PersonalityTests.Api.Migrations
{
    [DbContext(typeof(PersonalityTestDbContext))]
    partial class PersonalityTestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.CommonQuestionTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnName("deleted_on");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("LanguageId")
                        .HasColumnName("language_id");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("common_question_titles");
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnName("deleted_on");

                    b.Property<string>("EnglishName")
                        .HasColumnName("english_name");

                    b.Property<int>("EnumValue")
                        .HasColumnName("enum_value");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<string>("NativeName")
                        .HasColumnName("native_name");

                    b.HasKey("Id");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.OptionImageBinary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnName("deleted_on");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<string>("FileName")
                        .HasColumnName("file_name");

                    b.Property<byte[]>("ImageData")
                        .HasColumnName("image_data");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.HasKey("Id");

                    b.ToTable("option_image_binaries");
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.PersonalityTest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<Guid>("CustomerId")
                        .HasColumnName("customer_id");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnName("deleted_on");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsShared")
                        .HasColumnName("is_shared");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.HasKey("Id");

                    b.ToTable("personality_tests");
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.QuestionOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnName("deleted_on");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsTextOnly")
                        .HasColumnName("is_text_only");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<Guid?>("OptionImageBinaryId")
                        .HasColumnName("option_image_binary_id");

                    b.Property<Guid>("TestQuestionId")
                        .HasColumnName("test_question_id");

                    b.HasKey("Id");

                    b.HasIndex("OptionImageBinaryId");

                    b.HasIndex("TestQuestionId");

                    b.ToTable("question_options");
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.QuestionOptionTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnName("deleted_on");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("LanguageId")
                        .HasColumnName("language_id");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<Guid>("QuestionOptionId")
                        .HasColumnName("question_option_id");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("QuestionOptionId");

                    b.ToTable("question_option_titles");
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.ResultOptionMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnName("deleted_on");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<Guid>("QuestionOptionId")
                        .HasColumnName("question_option_id");

                    b.Property<Guid>("TestResultId")
                        .HasColumnName("test_result_id");

                    b.HasKey("Id");

                    b.HasIndex("QuestionOptionId");

                    b.HasIndex("TestResultId");

                    b.ToTable("result_option_maps");
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.TestQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnName("deleted_on");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<Guid>("PersonalityTestId")
                        .HasColumnName("personality_test_id");

                    b.Property<int>("SerialNumber")
                        .HasColumnName("serial_number");

                    b.HasKey("Id");

                    b.HasIndex("PersonalityTestId");

                    b.ToTable("test_questions");
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.TestQuestionTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<Guid>("CommonQuestionTitleId")
                        .HasColumnName("common_question_title_id");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnName("deleted_on");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<Guid>("TestQuestionId")
                        .HasColumnName("test_question_id");

                    b.HasKey("Id");

                    b.HasIndex("CommonQuestionTitleId");

                    b.HasIndex("TestQuestionId");

                    b.ToTable("test_question_titles");
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.TestResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnName("deleted_on");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<Guid>("PersonalityTestId")
                        .HasColumnName("personality_test_id");

                    b.Property<string>("Value")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("PersonalityTestId");

                    b.ToTable("test_results");
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.TestResultTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnName("deleted_on");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("LanguageId")
                        .HasColumnName("language_id");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<Guid>("TestResultId")
                        .HasColumnName("test_result_id");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("TestResultId");

                    b.ToTable("test_result_titles");
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.CommonQuestionTitle", b =>
                {
                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.Language", "Language")
                        .WithMany("CommonQuestionTitles")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.QuestionOption", b =>
                {
                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.OptionImageBinary", "OptionImageBinary")
                        .WithMany("QuestionOptions")
                        .HasForeignKey("OptionImageBinaryId");

                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.TestQuestion", "TestQuestion")
                        .WithMany("QuestionOptions")
                        .HasForeignKey("TestQuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.QuestionOptionTitle", b =>
                {
                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.Language", "Language")
                        .WithMany("QuestionOptionTitles")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.QuestionOption", "QuestionOption")
                        .WithMany("QuestionOptionTitles")
                        .HasForeignKey("QuestionOptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.ResultOptionMap", b =>
                {
                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.QuestionOption", "QuestionOption")
                        .WithMany("ResultOptionMaps")
                        .HasForeignKey("QuestionOptionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.TestResult", "TestResult")
                        .WithMany("ResultOptionMaps")
                        .HasForeignKey("TestResultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.TestQuestion", b =>
                {
                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.PersonalityTest", "PersonalityTest")
                        .WithMany("TestQuestions")
                        .HasForeignKey("PersonalityTestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.TestQuestionTitle", b =>
                {
                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.CommonQuestionTitle", "CommonQuestionTitle")
                        .WithMany("TestQuestionTitles")
                        .HasForeignKey("CommonQuestionTitleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.TestQuestion", "TestQuestion")
                        .WithMany("TestQuestionTitles")
                        .HasForeignKey("TestQuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.TestResult", b =>
                {
                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.PersonalityTest", "PersonalityTest")
                        .WithMany("TestResults")
                        .HasForeignKey("PersonalityTestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YngStrs.PersonalityTests.Api.Domain.Entities.TestResultTitle", b =>
                {
                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.Language", "Language")
                        .WithMany("TestResultTitles")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("YngStrs.PersonalityTests.Api.Domain.Entities.TestResult", "TestResult")
                        .WithMany("TestResultTitles")
                        .HasForeignKey("TestResultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
