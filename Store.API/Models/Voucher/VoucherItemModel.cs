using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Voucher
{
    public class VoucherItemModel
    {
        public long? VoucherId { get; set; }
        public string VoucherCode { get; set; }
    }
}
