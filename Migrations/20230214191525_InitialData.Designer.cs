﻿// <auto-generated />
using System;
using APITask.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APITask.Migrations
{
    [DbContext(typeof(APITaskContext))]
    [Migration("20230214191525_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APITask.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("peso")
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryID = new Guid("790eebd4-ed89-4366-8561-cce9488e52fa"),
                            name = "Pending activities",
                            peso = 20
                        },
                        new
                        {
                            CategoryID = new Guid("790eebd4-ed89-4366-8561-cce9488e5202"),
                            name = "Personal activities",
                            peso = 50
                        });
                });

            modelBuilder.Entity("APITask.Models.Task", b =>
                {
                    b.Property<Guid>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tittle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TaskID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            TaskID = new Guid("790eebd4-ed89-4366-8561-cce9488e5210"),
                            CategoryID = new Guid("790eebd4-ed89-4366-8561-cce9488e52fa"),
                            Deadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Priority = 1,
                            creationDate = new DateTime(2023, 2, 14, 14, 15, 25, 470, DateTimeKind.Local).AddTicks(8984),
                            tittle = "Public services pay"
                        },
                        new
                        {
                            TaskID = new Guid("790eebd4-ed89-4366-8561-cce9488e5211"),
                            CategoryID = new Guid("790eebd4-ed89-4366-8561-cce9488e5202"),
                            Deadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Priority = 0,
                            creationDate = new DateTime(2023, 2, 14, 14, 15, 25, 470, DateTimeKind.Local).AddTicks(9014),
                            tittle = "Finish Netflix series"
                        });
                });

            modelBuilder.Entity("APITask.Models.Task", b =>
                {
                    b.HasOne("APITask.Models.Category", "categoryInTask")
                        .WithMany("tasks")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoryInTask");
                });

            modelBuilder.Entity("APITask.Models.Category", b =>
                {
                    b.Navigation("tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
