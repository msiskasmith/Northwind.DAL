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
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly NorthwindDbContext _dbContext;

        public EmployeeRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetEmployeeAsync(Expression<Func<Employee, bool>> expression)
        {
            var result = await _dbContext.Set<Employee>().Where(expression)
                                    .Include(e => e.EmployeeSupervisor)
                                    .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int pageNumber, int numberOfRows)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<Employee>().Skip(skip).Take(numberOfRows)
                                    .Include(e => e.EmployeeSupervisor)
                                    .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int pageNumber, int numberOfRows, Expression<Func<Employee, bool>> expression)
        {
            var skip = (pageNumber - 1) * numberOfRows;

            var result = await _dbContext.Set<Employee>().Where(expression).Skip(skip).Take(numberOfRows)
                                    .Include(e => e.EmployeeSupervisor)
                                    .ToListAsync();
            return result;
        }

    }
}
