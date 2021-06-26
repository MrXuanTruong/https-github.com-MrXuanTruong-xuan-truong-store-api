using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("Vouchers")]
    public class Voucher: Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VoucherId { get; set; }
        public string VoucherCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal Price { get; set; }
        public long AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account{ get; set; }
        public int IsDeleted { get; set; }
        public int IsUsed { get; set; }
    }
}
