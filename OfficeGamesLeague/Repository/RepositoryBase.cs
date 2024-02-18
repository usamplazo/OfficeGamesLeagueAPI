using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeGamesLeague.UnitOfWork;
using System.Collections.Generic;

namespace OfficeGamesLeague.Repository
{
    public class RepositoryBase<T> : ControllerBase, IRepository<T> where T : class
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

        public async Task<ActionResult<T>> Delete(int id)
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

        public async Task<ActionResult<T>> Update(int id, T entity)
        {
            //TBD

            //if (id != entity.)
            //    return BadRequest();

            //T? existingEntity = await _dbSet.FindAsync(id);

            //if (existingEntity is null)
            //    return NotFound();

            //_unitOfWork.Context
            //        .Entry(existingEntity)
            //        .CurrentValues
            //        .SetValues(entity);
            //try
            //{
            //    await _unitOfWork.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    throw;
            //}

            return NoContent();
        }
    }
}
