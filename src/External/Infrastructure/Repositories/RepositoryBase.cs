using Application.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<T> : ControllerBase, IBaseRepository<T> where T : class
    {
        protected DbSet<T> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Context.Set<T>();
        }

        public async Task<ActionResult<T>> Create(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentException($"Failed to add entity to db of type {nameof(entity)}");
            }

            _dbSet.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IActionResult> Delete(int id)
        {
            T? data = await GetByID(id);

            if (data is null)
                return NotFound();

            _dbSet.Remove(data);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            List<T> data = await _dbSet.ToListAsync();
            return Ok(data);
        }

        public async Task<T?> GetByID(int id)
        {
            T? existingEntity = await _dbSet.FindAsync(id);
            return existingEntity;
        }

        public async Task<IActionResult> Update(int id, T entity)
        {
            //TBD

            //if (id != entity.)
            //return BadRequest();

            T? existingentity = await GetByID(id);

            if (existingentity is null)
                return NotFound();

            _unitOfWork.Context
                    .Entry(existingentity)
                    .CurrentValues
                    .SetValues(entity);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
               //tbd
            }

            return NoContent();
        }
    }
}
