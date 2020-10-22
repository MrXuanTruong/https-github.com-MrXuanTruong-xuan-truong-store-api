using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entity.Domains
{
    [Table("Provinces")]
    public class Province : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProvinceId { get; set; }
        [StringLength(50)]
        public string ProvinceName { get; set; }

    }
}