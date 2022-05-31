using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Northwind.DAL.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task AddAsync(T item);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetListAsync(int pageNumber, int numberOfRows);
        Task<IEnumerable<T>> GetListAsync(int pageNumber, int numberOfRows, Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}