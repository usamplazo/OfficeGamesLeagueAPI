using OfficeGamesLeague.Models;

namespace OfficeGamesLeague.UnitOfWork
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
            await _context.SaveChangesAsync();
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
