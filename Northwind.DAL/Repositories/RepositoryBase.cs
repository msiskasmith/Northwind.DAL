using Northwind.DAL.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Northwind.DAL.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly NorthwindDbContext _dbContext;

        public RepositoryBase(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T item)
        {
            await _dbContext.Set<T>().AddAsync(item);
        }

        public async Task<T> GetAsync(Expression<Func<T,bool>> expression)
        {
            var result = await _dbContext.Set<T>().FirstOrDefaultAsync(expression);

            return result;
        }

        public async Task<IEnumerable<T>> GetListAsync(int pageNumber, int numberOfRows)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<T>().Skip(skip).Take(numberOfRows).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<T>> GetListAsync(int pageNumber, int numberOfRows, Expression<Func<T, bool>> expression)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<T>().Where(expression).Skip(skip).Take(numberOfRows).ToListAsync();
            return result;
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AnyAsync(expression);
        }

        public async Task UpdateAsync(T entity)
        {
            await _dbContext.Set<T>().SingleUpdateAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _dbContext.Set<T>().SingleDeleteAsync(entity);
        }
    }
}
