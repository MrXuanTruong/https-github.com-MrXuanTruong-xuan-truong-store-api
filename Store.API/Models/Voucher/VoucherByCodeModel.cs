using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Voucher
{
    public class VoucherByCodeModel: ResponseModel
    {
        public decimal Price { get; set; }
    }
}
