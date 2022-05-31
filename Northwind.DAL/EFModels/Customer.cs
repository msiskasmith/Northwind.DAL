using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.DAL.EFModels
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContactName { get; set; }
        public string CustomerContactTitle { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public short? RegionId { get; set; }
        public string CustomerPostalCode { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerFax { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
