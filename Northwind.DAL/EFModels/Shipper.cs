using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.DAL.EFModels
{
    public partial class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        public short ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string ShipperPhone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
