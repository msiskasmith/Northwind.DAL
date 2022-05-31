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
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        private readonly NorthwindDbContext _dbContext;

        public ProductCategoryRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }


}
