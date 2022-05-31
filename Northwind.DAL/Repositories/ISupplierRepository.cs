using Northwind.DAL.EFModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Northwind.DAL.Repositories
{
    public interface ISupplierRepository : IRepositoryBase<Supplier>
    {
        Task<Supplier> GetSupplierAsync(Expression<Func<Supplier, bool>> expression);

        Task<IEnumerable<Supplier>> GetSuppliersAsync(int pageNumber, int numberOfRows);

        Task<IEnumerable<Supplier>> GetSuppliersAsync(int pageNumber, int numberOfRows, Expression<Func<Supplier, bool>> expression);
    }
}