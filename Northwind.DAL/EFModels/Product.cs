using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.DAL.EFModels
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public short ProductId { get; set; }
        public string ProductName { get; set; }
        public short? SupplierId { get; set; }
        public short? ProductCategoryId { get; set; }
        public string ProductQuantityPerUnit { get; set; }
        public float? ProductUnitPrice { get; set; }
        public short? ProductUnitsInStock { get; set; }
        public short? ProductUnitsOnOrder { get; set; }
        public short? ProductReorderLevel { get; set; }
        public int ProductDiscontinued { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
