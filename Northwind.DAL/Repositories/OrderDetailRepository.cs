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
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        private readonly NorthwindDbContext _dbContext;

        public OrderDetailRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderDetail> GetOrderDetailAsync(Expression<Func<OrderDetail, bool>> expression)
        {
            var result = await _dbContext.Set<OrderDetail>().Where(expression)
                                    .Include(o => o.Order)
                                    .Include(o => o.Product)
                                    .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync(int pageNumber, int numberOfRows)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<OrderDetail>().Skip(skip).Take(numberOfRows)
                                    .Include(o => o.Order)
                                    .Include(o => o.Product)
                                    .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync(int pageNumber, int numberOfRows, Expression<Func<OrderDetail, bool>> expression)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<OrderDetail>().Where(expression).Skip(skip).Take(numberOfRows)
                                    .Include(o => o.Order)
                                    .Include(o => o.Product)
                                    .ToListAsync();
            return result;
        }
    }
}
