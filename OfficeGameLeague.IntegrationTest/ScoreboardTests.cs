using OfficeGamesLeague.Models;
using OfficeGamesLeague.Repository;

namespace OfficeGameLeague.IntegrationTest
{
    public class ScoreboardTests : BaseIntegrationTest
    {
        public ScoreboardTests(IntegrationTestWebAppFactory factory) : base(factory) {}

        [Fact]
        public async Task CreateShouldAddNewScoreboard()
        {
            //Arrange
            Scoreboard newScoreboard = new()
            {
                ContestantId = 10,
                DisciplineId = 20,
                DateDisciplinePlayed = 20240108,
                TimeDisciplineStarted = DateTime.Now,
                TimeDisciplineFinished = DateTime.Now.AddMinutes(10),
            };
            IRepository<Scoreboard> scoreboardRepository = new ScoreboardRepository(_unitOfWork);

            //Act
            var result = await scoreboardRepository.Create(newScoreboard);

            //Assert
            var socreboard = _unitOfWork.Context.Scoreboards.FirstOrDefault(s => s.ScoreboardId == result.Value.ScoreboardId);
            Assert.NotNull(socreboard);
        }

        [Fact]
        public async Task GetByIDShouldReturnScoreboardWhenScoreboardExists()
        {
            //Arrange
            Scoreboard newScoreboard = new()
            {
                ContestantId = 10,
                DisciplineId = 20,
                DateDisciplinePlayed = 20240108,
                TimeDisciplineStarted = DateTime.Now,
                TimeDisciplineFinished = DateTime.Now.AddMinutes(10),
            };
            IRepository<Scoreboard> scoreboardRepository = new ScoreboardRepository(_unitOfWork);
            Scoreboard? scoreboard = (await scoreboardRepository.Create(newScoreboard)).Value;

            //Act
            Scoreboard? result = await scoreboardRepository.GetByID(scoreboard.ScoreboardId);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteShouldDeleteScoreboardWhenScoreboardExists()
        {
            //Arrange
            Scoreboard newScoreboard = new()
            {
                ContestantId = 10,
                DisciplineId = 20,
                DateDisciplinePlayed = 20240108,
                TimeDisciplineStarted = DateTime.Now,
                TimeDisciplineFinished = DateTime.Now.AddMinutes(10),
            };
            IRepository<Scoreboard> scoreboardRepository = new ScoreboardRepository(_unitOfWork);
            Scoreboard? scoreboard = (await scoreboardRepository.Create(newScoreboard)).Value;

            //Act
            await scoreboardRepository.Delete(scoreboard.ScoreboardId);

            //Assert
            Scoreboard? deletedScoreboard = await _unitOfWork.Context.Scoreboards.FindAsync(scoreboard.ScoreboardId);
            Assert.Null(deletedScoreboard);
        }

        [Fact]
        public async Task UpdateShouldUpdateScoreboardWhenScoreobardExists()
        {
            //Arrange
            Scoreboard newScoreboard = new()
            {
                ContestantId = 10,
                DisciplineId = 20,
                DateDisciplinePlayed = 20240108,
                TimeDisciplineStarted = DateTime.Now,
                TimeDisciplineFinished = DateTime.Now.AddMinutes(10),
            };
            IRepository<Scoreboard> scoreboardRepository = new ScoreboardRepository(_unitOfWork);
            Scoreboard? scoreboard = (await scoreboardRepository.Create(newScoreboard)).Value;

            scoreboard.DisciplineId = 30;
            scoreboard.ContestantId = 20;

            //Act
            await scoreboardRepository.Update(scoreboard.ScoreboardId, scoreboard);

            //Assert
            var updatedScoreboard = await _unitOfWork.Context.Scoreboards.FindAsync(scoreboard.ScoreboardId);
        }
    }
}
