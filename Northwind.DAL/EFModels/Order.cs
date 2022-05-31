using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.DAL.EFModels
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public short OrderId { get; set; }
        public string CustomerId { get; set; }
        public short? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? OrderRequiredDate { get; set; }
        public DateTime? OrderShippedDate { get; set; }
        public short? ShipperId { get; set; }
        public float? OrderFreight { get; set; }
        public string OrderShipName { get; set; }
        public string OrderShipAddress { get; set; }
        public string OrderShipCity { get; set; }
        public short? OrderShipRegionId { get; set; }
        public string OrderShipPostalCode { get; set; }
        public string OrderShipCountry { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Region OrderShipRegion { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
