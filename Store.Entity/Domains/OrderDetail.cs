using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("OrderDetails")]
    public class OrderDetail : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public long? ColorId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("ColorId")]
        public Color Color { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
