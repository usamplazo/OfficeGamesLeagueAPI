using Application.Abstrsction;
using Application.Abstrsction.Messaging;
using Application.Repository;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Scoreboards.Commands.CreateScoreboard
{
    public class CreateScoreboardCommandHandler : ICommandHandler<CreateScoreboardCommand>
    {
        private readonly IScorebaordRepository _scoreboardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateScoreboardCommandHandler(IScorebaordRepository scoreboardRepository, IUnitOfWork unitOfWork)
        {
            _scoreboardRepository = scoreboardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateScoreboardCommand request, CancellationToken cancellationToken)
        {
            var scoreboard = new Scoreboard(request.ScoreboardId
                                      , request.ContestantId
                                      , request.DisciplineId
                                      , request.DateDisciplinePlayed
                                      , request.CreatedOnUtc
                                      , request.ModifiedOnUtc);

            await _scoreboardRepository.Create(scoreboard);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //TBD
            return Result.Success();
        }
    }
}
