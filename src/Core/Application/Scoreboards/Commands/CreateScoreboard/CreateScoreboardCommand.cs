using Application.Abstrsction.Messaging;

namespace Application.Scoreboards.Commands.CreateScoreboard
{
  //sadrzi podatke koji su nam potrebni da bi napravili scoreboard objekat

    public sealed record CreateScoreboardCommand(int ScoreboardId
                                                ,int ContestantId
                                                ,int DisciplineId
                                                ,DateTime TimeDisciplineStarted
                                                ,DateTime TimeDisciplineFinished
                                                ,int DateDisciplinePlayed) : ICommand;

}
