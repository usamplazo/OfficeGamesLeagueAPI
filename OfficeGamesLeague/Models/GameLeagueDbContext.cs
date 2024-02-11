using Microsoft.EntityFrameworkCore;

namespace OfficeGamesLeague.Models
{
    public class GameLeagueDbContext : DbContext
    {
        public GameLeagueDbContext(DbContextOptions<GameLeagueDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Scoreboard> Scoreboards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contestant>()
                .HasData(
                    new Contestant
                    {
                        ContestantId = 1,
                        FirstName = "J",
                        LastName = "C",
                        Nickname = "Caksa",
                        IsAdmin = true,
                        Age = 25,
                    },
                    new Contestant
                    {
                        ContestantId = 2,
                        FirstName = "G",
                        LastName = "P",
                        Nickname = "Gypsy king",
                        IsAdmin = true,
                        Age = 23,
                    },
                    new Contestant
                    {
                        ContestantId = 3,
                        FirstName = "S",
                        LastName = "T",
                        Nickname = "Srdzan",
                        IsAdmin = true,
                        Age = 26,
                    }, new Contestant
                    {
                        ContestantId = 4,
                        FirstName = "V",
                        LastName = "T",
                        Nickname = "Csni",
                        IsAdmin = true,
                        Age = 23,
                    }
                );

            modelBuilder.Entity<Discipline>()
                .HasData(
                    new Discipline
                    {
                        DisciplineId = 10,
                        Name = "3UP",
                        DailyLimit = 1,
                        Points = 1.5f,
                        Description = "3UP description"
                    },
                    new Discipline
                    {
                        DisciplineId = 11,
                        Name = "Footbal Dice",
                        DailyLimit = 1,
                        Points = 1.25f,
                        Description = "Football Dice description"
                    },
                     new Discipline
                     {
                         DisciplineId = 12,
                         Name = "Uno",
                         DailyLimit = 4,
                         Points = 1f,
                         Description = "Uno description"
                     },
                     new Discipline
                     {
                         DisciplineId = 13,
                         Name = "Darts",
                         DailyLimit = 1,
                         Points = 1f,
                         Description = "Darts description"
                     }
                );

            modelBuilder.Entity<Scoreboard>()
                .HasData(
                    new Scoreboard
                    {
                        ScoreboardId = 5,
                        ContestantId = 20,
                        DisciplineId = 10,
                        DateDisciplinePlayed = 20240108,
                        TimeDisciplineStarted = DateTime.Now,
                        TimeDisciplineFinished = DateTime.Now.AddMinutes(10),
                    }
                );
        }
    }
}
