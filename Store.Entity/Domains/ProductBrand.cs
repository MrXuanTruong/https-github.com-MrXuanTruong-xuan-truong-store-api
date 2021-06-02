using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("ProductBrands")]
    public class ProductBrand:Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductBrandId { get; set; } // 1
        public string ProductBrandName { get; set; } // Honda

        public string Logo { get; set; }
        public List<Product> Products { get; set; }

        public int IsDeleted { get; set; }
    }
}
