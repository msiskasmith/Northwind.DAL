using Northwind.DAL.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Repositories
{
    public class UnitOfWork : IAsyncDisposable, IUnitOfWork
    {
        private readonly NorthwindDbContext _dbContext;

        public UnitOfWork(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;

            ProductCategories = new ProductCategoryRepository(_dbContext);
            Customers = new CustomerRepository(_dbContext);
            Employees = new EmployeeRepository(_dbContext);
            Orders = new OrderRepository(_dbContext);
            OrderDetails = new OrderDetailRepository(_dbContext);
            Products = new ProductRepository(_dbContext);
            Regions = new RegionRepository(_dbContext);
            Shippers = new ShipperRepository(_dbContext);
            Suppliers = new SupplierRepository(_dbContext);
        }

        public IProductCategoryRepository ProductCategories { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IOrderDetailRepository OrderDetails { get; private set; }
        public IProductRepository Products { get; private set; }
        public IRegionRepository Regions { get; private set; }
        public IShipperRepository Shippers { get; private set; }
        public ISupplierRepository Suppliers { get; private set; }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
