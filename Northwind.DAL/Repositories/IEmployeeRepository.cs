using Northwind.DAL.EFModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Northwind.DAL.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<Employee> GetEmployeeAsync(Expression<Func<Employee, bool>> expression);

        Task<IEnumerable<Employee>> GetEmployeesAsync(int pageNumber, int numberOfRows);

        Task<IEnumerable<Employee>> GetEmployeesAsync(int pageNumber, int numberOfRows, Expression<Func<Employee, bool>> expression);
    }
}