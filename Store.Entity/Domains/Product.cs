using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("Products")]
    public class Product: Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductId { set; get; } //Primary ko dc Null
        
        [StringLength(100)]
        public string ProductName { get; set; } // Winner

        public string ThumnailUrl { get; set; }

        public long? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public long? ProductBrandId { get; set; } 

        [ForeignKey("ProductBrandId")]
        public ProductBrand ProductBrand { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public List<ProductColor> ProductColors { get; set; }

        public List<ProductBranch> ProductBranchs { get; set; }
        //public List<OrderDetail> OrderDetails { get; set; }

        [Column(TypeName = "decimal(18,0)")]// 18 số ko chấm
        public decimal Price { set; get; } // Giá cơ bản

        public int? Stock { set; get; } // Hàng tồn kho

        public int ViewCount { set; get; }

        public long? ProductStatusId { get; set; }

        [ForeignKey("ProductStatusId")]
        public ProductStatus ProductStatus { get; set; }

        [StringLength(200)]
        public string Description { set; get; }

        
        public int IsDeleted { get; set; }
    }
}
