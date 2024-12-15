﻿using LimakAz.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LimakAz.Application.Interfaces.Repositories.Generic;

public interface IRepository<T> where T : BaseEntity

{
    Task<T?> GetAsync(int id, bool enableTracking = true);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
                      Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = true);

    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
                      Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = true);
    //Task<Paginate<T>> GetPagesAsync(Expression<Func<T, bool>>? predicate = null,
    //                                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    //                                Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
    //                                int index = 0, int size = 10, bool enableTracking = true);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> RemoveAsync(T entity);
}
