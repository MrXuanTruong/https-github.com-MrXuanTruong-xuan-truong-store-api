using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Order
{
    public class OrderDetailItemModel
    {
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public long? ColorId { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string ColorName { get; set; }
        public string ProductName { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
