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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly NorthwindDbContext _dbContext;

        public ProductRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductAsync(Expression<Func<Product, bool>> expression)
        {
            var result = await _dbContext.Set<Product>().Where(expression)
                                    .Include(p => p.ProductCategory)
                                    .Include(p => p.Supplier)
                                    .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int pageNumber, int numberOfRows)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<Product>().Skip(skip).Take(numberOfRows)
                                    .Include(p => p.ProductCategory)
                                    .Include(p => p.Supplier)
                                    .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int pageNumber, int numberOfRows, Expression<Func<Product, bool>> expression)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<Product>().Where(expression).Skip(skip).Take(numberOfRows)
                                    .Include(p => p.ProductCategory)
                                    .Include(p => p.Supplier)
                                    .ToListAsync();
            return result;
        }
    }
}
