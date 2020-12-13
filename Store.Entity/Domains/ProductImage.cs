using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("ProductImages")]
    public class ProductImage : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductImageId { get; set; }
       
        public string ProductImageUrl { get; set; }

        public long? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //public long? ProductId { get; set; }
        //[ForeignKey("ProductId")]
        //public Product Product { get; set; }

    }
}
