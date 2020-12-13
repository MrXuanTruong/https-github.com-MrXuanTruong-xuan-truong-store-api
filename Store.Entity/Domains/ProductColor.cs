using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("ProductColors")]
    public class ProductColor:Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductColorId { get; set; }

        //Product
        public long? ProductId { get; set; } // 1 | 1

        //Color
        public long ColorId { get; set; } // 1 | 1

        public double Price { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("ColorId")]
        public Color Color { get; set; }

       
    }
}
