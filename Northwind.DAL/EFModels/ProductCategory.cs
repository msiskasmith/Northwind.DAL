using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.DAL.EFModels
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public short ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryDescription { get; set; }
        public byte[] ProductCategoryPicture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
