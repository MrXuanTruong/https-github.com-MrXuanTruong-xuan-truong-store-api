using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Entity.Criteria
{
    public class VoucherCriteriaModel
    {
        public string VoucherCode { get; set; }
        public DateTime? FromStartDate { get; set; }
        public DateTime? ToStartDate { get; set; }
        public DateTime? FromEndDate { get; set; }
        public DateTime? ToEndDate { get; set; }
    }
}
