using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("ImportStockDetail")]
    public class ImportStockDetail : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ImportStockDetailId { get; set; }

        public long ImportStockId { get; set; }

        public long? ProductId { get; set; }

        public long ColorId { get; set; }

        public double Quantity { get; set; }

        public double Price { get; set; }

        [ForeignKey("ImportStockId")]
        public ImportStock ImportStock { get; set; }

    }
}
