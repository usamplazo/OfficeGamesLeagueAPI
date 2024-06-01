namespace Application.Repository
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync(CancellationToken cancellation = default);
    }
}
