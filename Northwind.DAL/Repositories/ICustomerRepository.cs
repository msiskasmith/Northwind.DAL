using Northwind.DAL.EFModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Northwind.DAL.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<Customer> GetCustomerAsync(Expression<Func<Customer, bool>> expression);

        Task<IEnumerable<Customer>> GetCustomersAsync(int pageNumber, int numberOfRows);

        Task<IEnumerable<Customer>> GetCustomersAsync(int pageNumber, int numberOfRows, Expression<Func<Customer, bool>> expression);
    }
}