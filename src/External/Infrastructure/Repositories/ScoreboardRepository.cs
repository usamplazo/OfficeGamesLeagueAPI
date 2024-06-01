using Application.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Infrastructure.Repositories
{
    public class ScoreboardRepository : RepositoryBase<Scoreboard>
    {
        protected DbSet<Scoreboard> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        private readonly CultureInfo enUs = new("en-US");

        public ScoreboardRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Context.Set<Scoreboard>();
        }

        public async Task<float> GetWeeklyScore(int contestandId, int? weekStart = null)
        {
            DateTime? test = DateTime.TryParseExact(weekStart.ToString(), "yyyyMMdd", enUs, DateTimeStyles.None, out DateTime dt) 
                                ? 
                                dt : 
                                DateTime.Now.AddDays(-DaysToSubstractForWeekStart);

            IEnumerable<int> disciplinesWonWeekly = await GetDisciplinesWonWeekly(contestandId, test).ConfigureAwait(false);

            if (disciplinesWonWeekly.Count() == 0)
                return 0;

            float totalWeekPoints =  disciplinesWonWeekly.SelectMany(disc => _unitOfWork.Context.Disciplines
                                                                                .Where(discipline => discipline.DisciplineId == disc)
                                                                                .Select(discipline => discipline.Points))
                                                            .Sum();
           
            return totalWeekPoints;
        }

        public async Task<IEnumerable<int>> GetDisciplinesWonWeekly(int contestandId, DateTime? weekStart)
        {
            return await _unitOfWork.Context.Scoreboards
                                        .Where(score => score.TimeDisciplineStarted.Date == weekStart
                                                        && score.ContestantId == contestandId)
                                        .Select(score => score.DisciplineId)
                                        .ToListAsync();
        }

        //public async Task<bool> IsContestantWeeklyActive(int contestantId)
        //{
        //    Scoreboard? scoreboard = await GetByID(contestantId);

        //    if (scoreboard is null)
        //        return false;

        //    return true;
        //}


        #region Properties

        //int currentDayOfWeek = (int)DateTime.Now.DayOfWeek;
        //return ((currentDayOfWeek - (int)DayOfWeek.Monday) + 7) % 7;
        public int DaysToSubstractForWeekStart => (int)DateTime.Now.DayOfWeek == 0 ? 6 : (int)DateTime.Now.DayOfWeek - 1;

        #endregion
    }
}
