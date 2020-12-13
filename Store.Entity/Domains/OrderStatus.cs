using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("OrderStatuses")]
    public class OrderStatus : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }

        public List<Order> Orders { get; set; }


    }
}
