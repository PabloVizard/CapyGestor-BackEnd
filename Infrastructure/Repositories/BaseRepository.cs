using Core.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<Entity> : IBaseRepository<Entity>, IDisposable where Entity : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<Entity> _dbSet;
        private List<Expression<Func<Entity, object>>> _includes = new();

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }

        // Permite encadear Includes antes dos métodos Find, List etc.
        public BaseRepository<Entity> Include(Expression<Func<Entity, object>> include)
        {
            _includes.Add(include);
            return this;
        }

        private IQueryable<Entity> ApplyIncludes(IQueryable<Entity> query)
        {
            foreach (var include in _includes)
            {
                query = query.Include(include);
            }
            _includes.Clear(); // Limpa os includes após o uso
            return query;
        }

        public bool Any(Expression<Func<Entity, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public IQueryable<Entity> AsNoTracking()
        {
            return _dbSet.AsNoTracking();
        }

        public Entity Find(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<Entity> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Entity FindBy(Expression<Func<Entity, bool>> predicate)
        {
            var query = ApplyIncludes(_dbSet.AsQueryable());
            return query.FirstOrDefault(predicate);
        }

        public async Task<Entity> FindByAsync(Expression<Func<Entity, bool>> predicate)
        {
            var query = ApplyIncludes(_dbSet.AsQueryable());
            return await query.FirstOrDefaultAsync(predicate);
        }

        public List<Entity> List()
        {
            var query = ApplyIncludes(_dbSet.AsQueryable());
            return query.ToList();
        }

        public async Task<List<Entity>> ListAsync()
        {
            var query = ApplyIncludes(_dbSet.AsQueryable());
            return await query.ToListAsync();
        }

        public List<Entity> List(Expression<Func<Entity, bool>> predicate)
        {
            var query = ApplyIncludes(_dbSet.AsQueryable());
            return query.Where(predicate).ToList();
        }

        public async Task<List<Entity>> ListAsync(Expression<Func<Entity, bool>> predicate)
        {
            var query = ApplyIncludes(_dbSet.AsQueryable());
            return await query.Where(predicate).ToListAsync();
        }

        public async Task<int> CountAsync(string searchTerm, string propertyName)
        {
            IQueryable<Entity> query = _dbSet;

            if (!string.IsNullOrWhiteSpace(searchTerm) && !string.IsNullOrWhiteSpace(propertyName))
            {
                var parameter = Expression.Parameter(typeof(Entity), "e");
                var property = Expression.Property(parameter, propertyName);
                var searchTermExpression = Expression.Constant(searchTerm);

                if (property.Type == typeof(string))
                {
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var containsExpression = Expression.Call(property, containsMethod, searchTermExpression);
                    var lambda = Expression.Lambda<Func<Entity, bool>>(containsExpression, parameter);
                    query = query.Where(lambda);
                }
                else
                {
                    var equalsExpression = Expression.Equal(property, Expression.Convert(searchTermExpression, property.Type));
                    var lambda = Expression.Lambda<Func<Entity, bool>>(equalsExpression, parameter);
                    query = query.Where(lambda);
                }
            }

            return await query.CountAsync();
        }

        public async Task<List<Entity>> ListPagedAsync(string searchTerm, string propertyName, int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<Entity> query = _dbSet;

            if (!string.IsNullOrWhiteSpace(searchTerm) && !string.IsNullOrWhiteSpace(propertyName))
            {
                var parameter = Expression.Parameter(typeof(Entity), "e");
                var property = Expression.Property(parameter, propertyName);
                var searchTermExpression = Expression.Constant(searchTerm);

                if (property.Type == typeof(string))
                {
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var containsExpression = Expression.Call(property, containsMethod, searchTermExpression);
                    var lambda = Expression.Lambda<Func<Entity, bool>>(containsExpression, parameter);
                    query = query.Where(lambda);
                }
                else
                {
                    var equalsExpression = Expression.Equal(property, Expression.Convert(searchTermExpression, property.Type));
                    var lambda = Expression.Lambda<Func<Entity, bool>>(equalsExpression, parameter);
                    query = query.Where(lambda);
                }
            }

            query = ApplyIncludes(query);

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public IQueryable<Entity> Query()
        {
            return _dbSet.AsQueryable();
        }

        public virtual async Task<object> Add(Entity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public void AddRange(IEnumerable<Entity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Remove(Entity entity, bool realDelete = false)
        {
            if (entity is IRemovivel removivel)
            {
                if (realDelete)
                {
                    _dbSet.Remove(entity);
                }
                else
                {
                    removivel.Removido = true;
                    _dbSet.Update(entity);
                }
            }
            else
            {
                _dbSet.Remove(entity);
            }
        }

        public void RemoveRange(IEnumerable<Entity> entities, bool realDelete = false)
        {
            foreach (var entity in entities)
            {
                Remove(entity, realDelete);
            }
        }

        public void Update(Entity entity)
        {
            _dbSet.Update(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        #region Disposed 
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
            }

            disposed = true;
        }
        #endregion
    }
}
