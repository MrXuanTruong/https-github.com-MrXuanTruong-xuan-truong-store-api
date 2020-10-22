using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Product
{
    public class ProductRequestModel
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [Required]
        public int ViewCount { get; set; }
        public string Description { get; set; }
        
    }
}
