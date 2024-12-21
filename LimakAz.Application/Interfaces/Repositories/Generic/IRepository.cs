using LimakAz.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LimakAz.Application.Interfaces.Repositories.Generic;

public interface IRepository<T> where T : BaseEntity

{
    Task<T?> GetAsync(int id, bool ignoreFilter = false);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
                      Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                      bool ignoreFilter = false);

    IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null,
                      Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                      bool ignoreFilter = false);
    IQueryable<T> GetPages(Expression<Func<T, bool>>? predicate = null,
                                Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                int page = 1, int limit = 10, bool ignoreFilter = false);


    IQueryable<T> OrderBy(IQueryable<T> query, Expression<Func<T, object>> predicate);
    IQueryable<T> OrderByDescending(IQueryable<T> query, Expression<Func<T, object>> predicate);
    Task<int> SaveChangesAsync();
    Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate, 
                            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreFilter = false);
    Task<T> CreateAsync(T entity);
    T UpdateAsync(T entity);
    void HardDelete(T entity);
    void SoftDelete(T entity);
    void Repair(T entity);
}
