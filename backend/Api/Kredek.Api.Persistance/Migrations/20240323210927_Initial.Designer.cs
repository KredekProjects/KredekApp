﻿// <auto-generated />
using System;
using Kredek.Api.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kredek.Api.Persistance.Migrations
{
    [DbContext(typeof(KredekDbContext))]
    [Migration("20240323210927_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kredek.Api.Persistance.Models.CourseModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriveFolderUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Courses", "KREDEK");
                });

            modelBuilder.Entity("Kredek.Api.Persistance.Models.CourseParticipantModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("ParticipantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("CourseParticipants", "KREDEK");
                });

            modelBuilder.Entity("Kredek.Api.Persistance.Models.LessonModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Presenter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons", "KREDEK");
                });

            modelBuilder.Entity("Kredek.Api.Persistance.Models.LessonParticipantModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("LessonId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("ParticipantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("LessonParticipants", "KREDEK");
                });

            modelBuilder.Entity("Kredek.Api.Persistance.Models.ParticipantModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CourseRepoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GithubUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Participants", "KREDEK");
                });

            modelBuilder.Entity("Kredek.Api.Persistance.Models.CourseParticipantModel", b =>
                {
                    b.HasOne("Kredek.Api.Persistance.Models.CourseModel", "Course")
                        .WithMany("CourseParticipants")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kredek.Api.Persistance.Models.ParticipantModel", "Participant")
                        .WithMany("CourseParticipants")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Kredek.Api.Persistance.Models.LessonModel", b =>
                {
                    b.HasOne("Kredek.Api.Persistance.Models.CourseModel", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Kredek.Api.Persistance.Models.LessonParticipantModel", b =>
                {
                    b.HasOne("Kredek.Api.Persistance.Models.LessonModel", "Lesson")
                        .WithMany("LessonParticipants")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kredek.Api.Persistance.Models.ParticipantModel", "Participant")
                        .WithMany("LessonParticipants")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Kredek.Api.Persistance.Models.CourseModel", b =>
                {
                    b.Navigation("CourseParticipants");

                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Kredek.Api.Persistance.Models.LessonModel", b =>
                {
                    b.Navigation("LessonParticipants");
                });

            modelBuilder.Entity("Kredek.Api.Persistance.Models.ParticipantModel", b =>
                {
                    b.Navigation("CourseParticipants");

                    b.Navigation("LessonParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
