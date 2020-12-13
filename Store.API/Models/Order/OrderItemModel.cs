using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Order
{
    public class OrderItemModel
    {
        public long OrderId { get; set; }
        public long OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public double TotalPrice { get; set; }
        public string OrderCode { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedDate { get; internal set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
    }
}
