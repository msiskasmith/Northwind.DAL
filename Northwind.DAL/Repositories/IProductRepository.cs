using Northwind.DAL.EFModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Northwind.DAL.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product> GetProductAsync(Expression<Func<Product, bool>> expression);

        Task<IEnumerable<Product>> GetProductsAsync(int pageNumber, int numberOfRows);

        Task<IEnumerable<Product>> GetProductsAsync(int pageNumber, int numberOfRows, Expression<Func<Product, bool>> expression);
    }
}