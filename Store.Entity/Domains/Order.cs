using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("Orders")]
    public class Order : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderId { get; set; }
        public string OrderCode { get; set; }
        public long CustomerId { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long OrderStatusId { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
        public long? PaymentMethodId { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

        public long? BranchId { get; set; }

        public long? VoucherId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        [ForeignKey("OrderStatusId")]
        public OrderStatus OrderStatus { get; set; }

        [ForeignKey("PaymentMethodId")]
        public PaymentMethod PaymentMethod { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}
