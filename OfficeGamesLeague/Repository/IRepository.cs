using Microsoft.AspNetCore.Mvc;

namespace OfficeGamesLeague.Repository
{
    public interface IRepository<T> where T : class
    {
        public Task<ActionResult<IEnumerable<T>>> Get();
        public Task<T?> GetByID(int id);
        public Task<ActionResult<T>> Create(T entity);
        public Task<ActionResult<T>> Update(int id, T entity);
        public Task<ActionResult<T>> Delete(int id);
    }
}
