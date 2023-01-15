﻿// <auto-generated />
using FilmoSearch.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmoSearch.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230115224352_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FilmoSearch.DAL.Entities.ActorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Actor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Vlad",
                            LastName = "Zagorsky"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Tyler",
                            LastName = "Durden"
                        });
                });

            modelBuilder.Entity("FilmoSearch.DAL.Entities.ActorEntityFilmEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("FilmId");

                    b.ToTable("ActorFilms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActorId = 1,
                            FilmId = 1
                        },
                        new
                        {
                            Id = 2,
                            ActorId = 2,
                            FilmId = 1
                        });
                });

            modelBuilder.Entity("FilmoSearch.DAL.Entities.FilmEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Film");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Dirty Jerry"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Alien"
                        });
                });

            modelBuilder.Entity("FilmoSearch.DAL.Entities.ReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Review");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Remarkable film with fascinating characters",
                            FilmId = 1,
                            Stars = 5,
                            Title = "Review for Dirty Jerry"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Vulgar movie with a bunch of flat jokes",
                            FilmId = 1,
                            Stars = 2,
                            Title = "Review for Dirty Jerry"
                        });
                });

            modelBuilder.Entity("FilmoSearch.DAL.Entities.ActorEntityFilmEntity", b =>
                {
                    b.HasOne("FilmoSearch.DAL.Entities.ActorEntity", "Actor")
                        .WithMany("ActorFilms")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmoSearch.DAL.Entities.FilmEntity", "Film")
                        .WithMany("ActorFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("FilmoSearch.DAL.Entities.ReviewEntity", b =>
                {
                    b.HasOne("FilmoSearch.DAL.Entities.FilmEntity", "Film")
                        .WithMany("Reviews")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("FilmoSearch.DAL.Entities.ActorEntity", b =>
                {
                    b.Navigation("ActorFilms");
                });

            modelBuilder.Entity("FilmoSearch.DAL.Entities.FilmEntity", b =>
                {
                    b.Navigation("ActorFilms");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}