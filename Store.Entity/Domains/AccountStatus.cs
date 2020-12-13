using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("AccountStatuses")]
    public class AccountStatus:Entity
    {
        [Key]
        public long AccountStatusId { get; set; }

        [StringLength(100)]
        public string AccountStatusName { get; set; }
    }
}
