using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.DAL.EFModels
{
    public partial class Region
    {
        public Region()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
            Orders = new HashSet<Order>();
            Suppliers = new HashSet<Supplier>();
        }

        public short RegionId { get; set; }
        public string RegionDescription { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
