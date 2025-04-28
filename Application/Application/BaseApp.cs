using Application.Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Application.Models;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class BaseApp<Entity, Model> : IBaseApp<Entity, Model> where Entity : BaseEntity where Model : BaseModel
    {
        private readonly IBaseService<Entity> _baseService;
        private readonly IMapper _mapper;

        public BaseApp(IBaseService<Entity> baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }
        public IBaseApp<Entity, Model> Include(Expression<Func<Entity, object>> include)
        {
            _baseService.Include(include);
            return this;
        }

        public bool Any(Expression<Func<Entity, bool>> predicate)
        {
            return _baseService.Any(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _baseService.AnyAsync(predicate);
        }
        public IQueryable<Entity> AsNoTracking()
        {
            return _baseService.AsNoTracking();
        }

        public Entity Find(int id)
        {
            return _baseService.Find(id);
        }

        public async Task<Entity> FindAsync(int id)
        {
            return await _baseService.FindAsync(id);
        }

        public Entity FindBy(Expression<Func<Entity, bool>> predicate)
        {
            return _baseService.FindBy(predicate);
        }

        public async Task<Entity> FindByAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _baseService.FindByAsync(predicate);
        }

        public List<Entity> List()
        {
            return _baseService.List();
        }

        public async Task<List<Entity>> ListAsync()
        {
            return await _baseService.ListAsync();
        }

        public List<Entity> List(Expression<Func<Entity, bool>> predicate)
        {
            return _baseService.List(predicate);
        }

        public async Task<List<Entity>> ListAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _baseService.ListAsync(predicate);
        }
        public async Task<PagedResultModel<Model>> ListPagedAsync(string searchTerm, string propertyName, int pageNumber, int pageSize)
        {
            var items = await _baseService.ListPagedAsync(searchTerm, propertyName, pageNumber, pageSize);
            var totalCount = await _baseService.CountAsync(searchTerm, propertyName);

            var mappedItems = _mapper.Map<List<Model>>(items);

            return new PagedResultModel<Model>(mappedItems, totalCount, pageNumber, pageSize);
        }

        public IQueryable<Entity> Query()
        {
            return _baseService.Query();
        }

        public virtual async Task<object> Add(Model dado)
        {
            return await _baseService.Add(_mapper.Map<Entity>(dado));
        }

        public void AddRange(IEnumerable<Entity> entities)
        {
            _baseService.AddRange(entities);
        }

        public void Remove(Entity entity, bool realDelete = false)
        {
            _baseService.Remove(entity, realDelete);
        }

        public void RemoveRange(IEnumerable<Entity> entities, bool realDelete = false)
        {
            _baseService.RemoveRange(entities, realDelete);
        }

        public void Update(Entity dado)
        {
            _baseService.Update((dado));
        }

        public async Task SaveChangesAsync()
        {
            await _baseService.SaveChangesAsync();
        }
    }
}
