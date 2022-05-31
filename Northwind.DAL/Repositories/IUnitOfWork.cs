using System.Threading.Tasks;

namespace Northwind.DAL.Repositories
{
    public interface IUnitOfWork
    {
        IProductCategoryRepository ProductCategories { get; }
        ICustomerRepository Customers { get; }
        IEmployeeRepository Employees { get; }
        IOrderDetailRepository OrderDetails { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        IRegionRepository Regions { get; }
        IShipperRepository Shippers { get; }
        ISupplierRepository Suppliers { get; }

        Task<int> SaveChanges();
    }
}