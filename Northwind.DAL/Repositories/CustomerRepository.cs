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
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly NorthwindDbContext _dbContext;

        public CustomerRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> GetCustomerAsync(Expression<Func<Customer, bool>> expression)
        {
            var result = await _dbContext.Set<Customer>().Where(expression)
                                .Include(c => c.Region)
                                .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(int pageNumber, int numberOfRows)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<Customer>().Skip(skip).Take(numberOfRows)
                                    .Include(c => c.Region)
                                    .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(int pageNumber, int numberOfRows, Expression<Func<Customer, bool>> expression)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<Customer>().Where(expression).Skip(skip).Take(numberOfRows)
                                    .Include(c => c.Region)
                                    .ToListAsync();
            return result;
        }

    }
}
