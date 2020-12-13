using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("ExportStockDetail")]
    public class ExportStockDetail : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? ExportStockDetailId { get; set; }

        public long ProductId { get; set; }
        public long ExportStockId { get; set; }

        public long? ColorId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        [ForeignKey("ExportStockId")]
        public ExportStock ExportStock { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
