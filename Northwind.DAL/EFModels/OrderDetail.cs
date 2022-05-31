using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.DAL.EFModels
{
    public partial class OrderDetail
    {
        public short OrderDetailId { get; set; }
        public short OrderId { get; set; }
        public short ProductId { get; set; }
        public float OrderUnitPrice { get; set; }
        public short OrderQuantity { get; set; }
        public float OrderDiscount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
