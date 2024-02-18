using OfficeGamesLeague.Models;
using OfficeGamesLeague.UnitOfWork;

namespace OfficeGamesLeague.Repository
{
    public class ScoreboardRepository : RepositoryBase<Scoreboard>
    {
        public ScoreboardRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
