﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : BaseEntity
    {
        IBaseRepository<Entity> Include(Expression<Func<Entity, object>> include);
        bool Any(Expression<Func<Entity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<Entity, bool>> predicate);

        IQueryable<Entity> AsNoTracking();

        Entity Find(int id);
        Task<Entity> FindAsync(int id);

        Entity FindBy(Expression<Func<Entity, bool>> predicate);
        Task<Entity> FindByAsync(Expression<Func<Entity, bool>> predicate);

        List<Entity> List();
        Task<List<Entity>> ListAsync();

        List<Entity> List(Expression<Func<Entity, bool>> predicate);
        Task<List<Entity>> ListAsync(Expression<Func<Entity, bool>> predicate);
        Task<List<Entity>> ListPagedAsync(string searchTerm, string propertyName, int pageNumber, int pageSize);
        Task<int> CountAsync(string searchTerm, string propertyName);
        IQueryable<Entity> Query();

        Task<object> Add(Entity entity);
        void AddRange(IEnumerable<Entity> entities);

        void Remove(Entity entity, bool realDelete = false);
        void RemoveRange(IEnumerable<Entity> entities, bool realDelete = false);

        void Update(Entity entity);

        void SaveChanges();
        Task SaveChangesAsync();

    }
}
