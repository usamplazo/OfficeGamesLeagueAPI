﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OfficeGamesLeague.Models;

#nullable disable

namespace OfficeGamesLeague.Migrations
{
    [DbContext(typeof(GameLeagueDbContext))]
    partial class GameLeagueDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OfficeGamesLeague.Models.Contestant", b =>
                {
                    b.Property<int>("ContestantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContestantId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ContestantId");

                    b.ToTable("Contestants");

                    b.HasData(
                        new
                        {
                            ContestantId = 1,
                            Age = 25,
                            FirstName = "J",
                            IsAdmin = true,
                            LastName = "C",
                            Nickname = "Caksa"
                        },
                        new
                        {
                            ContestantId = 2,
                            Age = 23,
                            FirstName = "G",
                            IsAdmin = true,
                            LastName = "P",
                            Nickname = "Gypsy king"
                        },
                        new
                        {
                            ContestantId = 3,
                            Age = 26,
                            FirstName = "S",
                            IsAdmin = true,
                            LastName = "T",
                            Nickname = "Srdzan"
                        },
                        new
                        {
                            ContestantId = 4,
                            Age = 23,
                            FirstName = "V",
                            IsAdmin = true,
                            LastName = "T",
                            Nickname = "Csni"
                        });
                });

            modelBuilder.Entity("OfficeGamesLeague.Models.Discipline", b =>
                {
                    b.Property<int>("DisciplineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisciplineId"));

                    b.Property<int>("DailyLimit")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<float>("Points")
                        .HasColumnType("real");

                    b.HasKey("DisciplineId");

                    b.ToTable("Disciplines");

                    b.HasData(
                        new
                        {
                            DisciplineId = 10,
                            DailyLimit = 1,
                            Description = "3UP description",
                            Name = "3UP",
                            Points = 1.5f
                        },
                        new
                        {
                            DisciplineId = 11,
                            DailyLimit = 1,
                            Description = "Football Dice description",
                            Name = "Footbal Dice",
                            Points = 1.25f
                        },
                        new
                        {
                            DisciplineId = 12,
                            DailyLimit = 4,
                            Description = "Uno description",
                            Name = "Uno",
                            Points = 1f
                        },
                        new
                        {
                            DisciplineId = 13,
                            DailyLimit = 1,
                            Description = "Darts description",
                            Name = "Darts",
                            Points = 1f
                        });
                });

            modelBuilder.Entity("OfficeGamesLeague.Models.Scoreboard", b =>
                {
                    b.Property<int>("ScoreboardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScoreboardId"));

                    b.Property<int>("ContestantId")
                        .HasColumnType("int");

                    b.Property<int>("DateDisciplinePlayed")
                        .HasColumnType("int");

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeDisciplineFinished")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeDisciplineStarted")
                        .HasColumnType("datetime2");

                    b.HasKey("ScoreboardId");

                    b.ToTable("Scoreboards");

                    b.HasData(
                        new
                        {
                            ScoreboardId = 5,
                            ContestantId = 20,
                            DateDisciplinePlayed = 20240108,
                            DisciplineId = 10,
                            TimeDisciplineFinished = new DateTime(2024, 2, 11, 13, 24, 14, 670, DateTimeKind.Local).AddTicks(5823),
                            TimeDisciplineStarted = new DateTime(2024, 2, 11, 13, 14, 14, 670, DateTimeKind.Local).AddTicks(5779)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
