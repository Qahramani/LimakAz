﻿using LimakAz.Application.Interfaces.Repositories.Generic;
using LimakAz.Domain.Entities.Common;
using LimakAz.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LimakAz.Persistence.Implementations.Repositories.Generic;

internal class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<T> _table;
    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;

        _table = _dbContext.Set<T>();
    }

    public async Task<T> CreateAsync(T entity)
    {
        var entityEntry = await _table.AddAsync(entity);

        return entityEntry.Entity;
    }

    public T Update(T entity)
    {
        var entityEntry = _table.Update(entity);

        return entityEntry.Entity;
    }

    public void SoftDelete(T entity)
    {
        if (entity is BaseAuditableEntity baseAuditableEntity)
        {
            baseAuditableEntity.IsDeleted = true;
        }
    }

    public void HardDelete(T entity)
    {
        _table.Remove(entity);
    }

    public void Repair(T entity)
    {
        if (entity is BaseAuditableEntity baseAuditable)
        {
            baseAuditable.IsDeleted = false;
        }
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreFilter = false)
    {
        IQueryable<T> query = _table.AsQueryable();

        if (predicate != null)
            query = query.Where(predicate);

        if (include != null)
            query = include(query);

        if (ignoreFilter)
            query = query.IgnoreQueryFilters();

        return query;
    }

    public async Task<T?> GetAsync(int id, bool ignoreFilter = false)
    {
        IQueryable<T> query = _table.AsQueryable();

        if (ignoreFilter)
            query = query.IgnoreQueryFilters();

        var entity = await query.FirstOrDefaultAsync(x => x.Id == id);

        return entity;
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreFilter = false)
    {
        IQueryable<T> query = _table.AsQueryable();

        if (include != null)
            query = include(query);

        if (ignoreFilter)
            query = query.IgnoreQueryFilters();

        var entity = await query.FirstOrDefaultAsync(predicate);

        return entity;
    }

    //public IQueryable<T> GetPages(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int page = 1, int limit = 10, bool ignoreFilter = false)
    //{
    //    IQueryable<T> query = _table.AsQueryable();

    //    if (predicate != null)
    //        query = query.Where(predicate);

    //    if (include != null)
    //        query = include(query);

    //    if (ignoreFilter)
    //        query = query.IgnoreQueryFilters();

    //    query = query.Skip((page - 1) * limit).Take(limit);

    //    return query;
    //}
    public IQueryable<T> Paginate(IQueryable<T> query, int limit, int page = 1)
    {
        IQueryable<T> result = query.Skip((page - 1) * limit).Take(limit);
        return result;
    }

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreFilter = false)
    {
        IQueryable<T> query = _table.AsQueryable();

        if (include != null)
            query = query.Include(predicate);

        if (ignoreFilter)
            query = query.IgnoreQueryFilters();

        var result = await _table.AnyAsync(predicate);

        return result;
    }

    public IQueryable<T> OrderBy(IQueryable<T> query, Expression<Func<T, object>> predicate)
    {
        return query.OrderBy(predicate);
    }

    public IQueryable<T> OrderByDescending(IQueryable<T> query, Expression<Func<T, object>> predicate)
    {
        return query.OrderByDescending(predicate);
    }


    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
