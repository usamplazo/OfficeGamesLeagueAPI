using OfficeGamesLeague.Models;

namespace OfficeGamesLeague.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GameLeagueDbContext Context { get; }
        public Task SaveChangesAsync();
    }
}
