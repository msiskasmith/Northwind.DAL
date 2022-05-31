using Northwind.DAL.EFModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Northwind.DAL.Repositories
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<Order> GetOrderAsync(Expression<Func<Order, bool>> expression);

        Task<IEnumerable<Order>> GetOrdersAsync(int pageNumber, int numberOfRows);

        Task<IEnumerable<Order>> GetOrdersAsync(int pageNumber, int numberOfRows, Expression<Func<Order, bool>> expression);
    }   
}