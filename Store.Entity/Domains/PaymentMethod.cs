using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("PaymentMethods")]
    public class PaymentMethod : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
        public List<Order> Orders { get; set; }

    }
}
