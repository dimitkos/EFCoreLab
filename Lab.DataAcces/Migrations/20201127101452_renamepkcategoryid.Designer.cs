﻿// <auto-generated />
using System;
using Lab.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201127101452_renamepkcategoryid")]
    partial class renamepkcategoryid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Lab.Model.Models.Author", b =>
                {
                    b.Property<int>("Author_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Author_Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Lab.Model.Models.Book", b =>
                {
                    b.Property<int>("Book_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Book_Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Lab.Model.Models.Category", b =>
                {
                    b.Property<int>("Category_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Category_Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Lab.Model.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("GenreId");

                    b.ToTable("tb_genre");
                });

            modelBuilder.Entity("Lab.Model.Models.Publisher", b =>
                {
                    b.Property<int>("Publisher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Publisher_Id");

                    b.ToTable("Publishers");
                });
#pragma warning restore 612, 618
        }
    }
}
