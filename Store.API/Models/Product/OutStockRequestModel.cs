using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Store.API.Models.Product
{
    public class OutStockRequestModel
    {
        public long OrderId { get; set; }
        public long ExportStockCode { get; set; }
        public List<OutStockDetailModel> Details { get; set; }
        public string Note { get; set; }
    }
}
