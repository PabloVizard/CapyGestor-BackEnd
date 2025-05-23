﻿using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Interfaces
{
    public interface IBaseApp<Entity, Model> where Entity : BaseEntity where Model : BaseModel
    {
        IBaseApp<Entity, Model> Include(Expression<Func<Entity, object>> include);
        bool Any(Expression<Func<Entity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<Entity, bool>> predicate);
        Entity Find(int id);
        Task<Entity> FindAsync(int id);
        IQueryable<Entity> AsNoTracking();
        Entity FindBy(Expression<Func<Entity, bool>> predicate);
        Task<Entity> FindByAsync(Expression<Func<Entity, bool>> predicate);
        List<Entity> List();
        Task<List<Entity>> ListAsync();
        List<Entity> List(Expression<Func<Entity, bool>> predicate);
        Task<List<Entity>> ListAsync(Expression<Func<Entity, bool>> predicate);
        Task<PagedResultModel<Model>> ListPagedAsync(string searchTerm, string propertyName, int pageNumber, int pageSize);
        IQueryable<Entity> Query();
        Task<object> Add(Model dado);
        void AddRange(IEnumerable<Entity> entities);
        void Remove(Entity entity, bool realDelete = false);
        void RemoveRange(IEnumerable<Entity> entities, bool realDelete = false);
        void Update(Entity dado);
        Task SaveChangesAsync();
    }
}
