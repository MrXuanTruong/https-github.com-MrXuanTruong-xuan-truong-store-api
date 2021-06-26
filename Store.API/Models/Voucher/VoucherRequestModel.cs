using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Voucher
{
    public class VoucherRequestModel
    {
        public long VoucherId { get; set; }
        public string VoucherCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public long AccountId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
    }
}
