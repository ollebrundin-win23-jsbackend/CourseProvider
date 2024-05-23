using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CourseProvider.Repos
{
    public abstract class BaseRepo<TEntity, TContext>
            where TEntity : class
            where TContext : DbContext
    {
        private readonly TContext _context;
        public BaseRepo(TContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> CreateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
                if (entity != null)
                {
                    return entity;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var entityList = await _context.Set<TEntity>().ToListAsync();
                return entityList;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null!;
            }
        }

        public virtual async Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity entity)
        {
            try
            {
                var currentEntity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
                if (currentEntity != null)
                {
                    _context.Entry(currentEntity).CurrentValues.SetValues(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
                if (entity != null)
                {
                    _context.Set<TEntity>().Remove(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
