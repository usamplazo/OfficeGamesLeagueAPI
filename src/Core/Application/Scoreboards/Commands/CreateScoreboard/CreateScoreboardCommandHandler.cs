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
            _unitOfWork = unitOfWork;
            _scoreboardRepository = scoreboardRepository;
        }

        public async Task<Result> Handle(CreateScoreboardCommand request, CancellationToken cancellationToken)
        {
            var scoreboard = new Scoreboard(request.ScoreboardId
                                            ,request.ContestantId
                                            ,request.DisciplineId
                                            ,request.TimeDisciplineStarted
                                            ,request.TimeDisciplineFinished
                                            ,request.DateDisciplinePlayed
                                            ,cancellationToken);

            _scoreboardRepository.Create(scoreboard);

            _ = await _unitOfWork.SaveChangesAsync(cancellationToken);


            //TBD
            return null;
        }
    }
}
