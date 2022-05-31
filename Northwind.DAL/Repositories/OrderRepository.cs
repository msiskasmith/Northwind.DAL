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
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly NorthwindDbContext _dbContext;
        public OrderRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> GetOrderAsync(Expression<Func<Order, bool>> expression)
        {
            var result = await _dbContext.Set<Order>().Where(expression)
                                    .Include(o => o.Customer)
                                    .Include(o => o.Employee)
                                    .Include(o => o.OrderShipRegion)
                                    .Include(o => o.Shipper)
                                    .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(int pageNumber, int numberOfRows)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<Order>().Skip(skip).Take(numberOfRows)
                                    .Include(o => o.Customer)
                                    .Include(o => o.Employee)
                                    .Include(o => o.OrderShipRegion)
                                    .Include(o => o.Shipper)
                                    .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(int pageNumber, int numberOfRows, Expression<Func<Order, bool>> expression)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<Order>().Where(expression).Skip(skip).Take(numberOfRows)
                                    .Include(o => o.Customer)
                                    .Include(o => o.Employee)
                                    .Include(o => o.OrderShipRegion)
                                    .Include(o => o.Shipper)
                                    .ToListAsync();
            return result;
        }
    }
}
