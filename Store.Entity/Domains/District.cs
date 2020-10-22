using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entity.Domains
{
    [Table("Districts")]
    public class District : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DistrictId { get; set; }
        [StringLength(50)]
        public string DistrictName { get; set; }

    }
}