using Northwind.DAL.EFModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Northwind.DAL.Repositories
{
    public interface IOrderDetailRepository : IRepositoryBase<OrderDetail>
    {
        Task<OrderDetail> GetOrderDetailAsync(Expression<Func<OrderDetail, bool>> expression);

        Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync(int pageNumber, int numberOfRows);

        Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync(int pageNumber, int numberOfRows, Expression<Func<OrderDetail, bool>> expression);
    }
}