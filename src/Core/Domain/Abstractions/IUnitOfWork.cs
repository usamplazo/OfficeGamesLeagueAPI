namespace Application.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        //GameLeagueDbContext Context { get; }
        public Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}
