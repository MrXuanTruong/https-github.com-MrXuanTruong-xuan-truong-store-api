using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Order
{
    public class OrderDetailModel
    {
        public long OrderDetailId { get; set; }
        public long ProductId { get; set; }
        public long? ColorId { get; set; }
        public int Quantity { get; set; }
    }
}
