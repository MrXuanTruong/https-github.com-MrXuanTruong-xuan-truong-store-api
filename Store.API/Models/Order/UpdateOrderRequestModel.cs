using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Order
{
    public class UpdateOrderRequestModel
    {
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public string Note { get; set; }
        public long OrderStatusId { get; set; }
        public long? PaymentMethodId { get; set; }
        public long? BranchId { get; set; }
        

        public List<OrderDetailModel> OrderDetails { get; set; }
    }
}
