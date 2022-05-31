using Microsoft.EntityFrameworkCore;
using Northwind.DAL.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        private readonly NorthwindDbContext _dbContext;

        public SupplierRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Supplier> GetSupplierAsync(Expression<Func<Supplier, bool>> expression)
        {
            var result = await _dbContext.Set<Supplier>().Where(expression)
                                    .Include(s => s.Region)
                                    .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync(int pageNumber, int numberOfRows)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<Supplier>().Skip(skip).Take(numberOfRows)
                                    .Include(s => s.Region)
                                    .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync(int pageNumber, int numberOfRows, Expression<Func<Supplier, bool>> expression)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<Supplier>().Where(expression).Skip(skip).Take(numberOfRows)
                                    .Include(s => s.Region)
                                    .ToListAsync();
            return result;
        }
    }
}
