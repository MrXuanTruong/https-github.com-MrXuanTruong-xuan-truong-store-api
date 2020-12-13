using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Order
{
    public class CreateOrderResponseModel : ResponseModel
    {
        public string OrderCode { get; set; }
        public long OrderId { get; set; }
    }
}
