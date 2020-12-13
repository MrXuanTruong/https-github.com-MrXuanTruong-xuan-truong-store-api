using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Order
{
    public class OrderRequestModel
    {
        public long OrderId { get; set; }
        public string OrderCode { get; set; }
        public long CustomerId { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long OrderStatusId { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
        //public long PaymentmethodId { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public long? PaymentMethodId { get; set; }
        public long? BranchId { get; set; }
        
        public string PaymentMethodName { get; set; }
        public string OrderStatusName { get; set; }
        public string BranchName { get; set; }
        public List<OrderDetailItemModel> OrderDetails { get; set; }

    }
}
