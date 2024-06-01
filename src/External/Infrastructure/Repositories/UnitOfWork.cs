using Application.Repository;
using Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameLeagueDbContext _context;
        private bool _disposed = false;

        public UnitOfWork(GameLeagueDbContext context)
        {
            _context = context;
        }

        #region Overrides

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // use an optimistic concurrency strategy from:
                // https://learn.microsoft.com/en-us/ef/core/saving/concurrency#resolving-concurrency-conflicts
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        #endregion

        #region Properties

        public GameLeagueDbContext Context => _context;

        #endregion
    }
}
