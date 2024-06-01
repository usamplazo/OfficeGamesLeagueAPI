using Microsoft.AspNetCore.Mvc;

namespace Application.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<ActionResult<IEnumerable<T>>> Get();
        public Task<T?> GetByIDAsync(int id);
        public Task<ActionResult<T>> Create(T entity);
        public Task<IActionResult> Update(int id, T entity);
        public Task<IActionResult> Delete(int id);
    }
}
 