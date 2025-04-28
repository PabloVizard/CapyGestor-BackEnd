using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class BaseService<Entity> : IBaseService<Entity> where Entity : BaseEntity
    {
        protected readonly IBaseRepository<Entity> _repository;
        protected readonly IMapper _mapper;

        protected BaseService(IBaseRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IBaseService<Entity> Include(Expression<Func<Entity, object>> include)
        {
            _repository.Include(include);
            return this;
        }

        public virtual bool Any(Expression<Func<Entity, bool>> predicate)
        {
            return _repository.Any(predicate);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _repository.AnyAsync(predicate);
        }

        public virtual IQueryable<Entity> AsNoTracking()
        {
            return _repository.AsNoTracking();
        }

        public virtual Entity Find(int id)
        {
            return _repository.Find(id);
        }

        public virtual async Task<Entity> FindAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public virtual Entity FindBy(Expression<Func<Entity, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public virtual async Task<Entity> FindByAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _repository.FindByAsync(predicate);
        }

        public virtual List<Entity> List()
        {
            return _repository.List();
        }

        public virtual async Task<List<Entity>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public virtual List<Entity> List(Expression<Func<Entity, bool>> predicate)
        {
            return _repository.List(predicate);
        }

        public virtual async Task<List<Entity>> ListAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _repository.ListAsync(predicate);
        }

        public virtual async Task<List<Entity>> ListPagedAsync(string searchTerm, string propertyName, int pageNumber, int pageSize)
        {
            return await _repository.ListPagedAsync(searchTerm, propertyName, pageNumber, pageSize);
        }

        public virtual async Task<int> CountAsync(string searchTerm, string propertyName)
        {
            return await _repository.CountAsync(searchTerm, propertyName);
        }

        public virtual IQueryable<Entity> Query()
        {
            return _repository.Query();
        }

        public virtual async Task<object> Add(Entity entity)
        {
            var result = await _repository.Add(entity);
            await _repository.SaveChangesAsync();
            return result;
        }

        public virtual void AddRange(IEnumerable<Entity> entities)
        {
            _repository.AddRange(entities);
        }

        public virtual void Remove(Entity entity, bool realDelete = false)
        {
            _repository.Remove(entity, realDelete);
        }

        public virtual void RemoveRange(IEnumerable<Entity> entities, bool realDelete = false)
        {
            _repository.RemoveRange(entities, realDelete);
        }

        public virtual void Update(Entity entity)
        {
            _repository.Update(entity);
        }

        public virtual async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }
    }
}
