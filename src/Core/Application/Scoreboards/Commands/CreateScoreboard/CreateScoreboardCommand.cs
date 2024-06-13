using Application.Abstrsction.Messaging;

namespace Application.Scoreboards.Commands.CreateScoreboard
{
  //sadrzi podatke koji su nam potrebni da bi napravili scoreboard objekat

    public sealed record CreateScoreboardCommand(Guid ScoreboardId
                                                ,Guid ContestantId
                                                ,Guid DisciplineId
                                                ,int DateDisciplinePlayed 
                                                ,DateTime CreatedOnUtc
                                                ,DateTime? ModifiedOnUtc) : ICommand;

}
