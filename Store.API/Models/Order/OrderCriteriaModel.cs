using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Order
{
    public class OrderCriteriaModel
    {
        public long? OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
    }
}
