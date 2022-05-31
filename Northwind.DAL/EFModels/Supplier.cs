using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.DAL.EFModels
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public short SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierContactName { get; set; }
        public string SupplierContactTitle { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierCity { get; set; }
        public short? RegionId { get; set; }
        public string SupplierPostalCode { get; set; }
        public string SupplierCountry { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierFax { get; set; }
        public string SupplierHomepage { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
