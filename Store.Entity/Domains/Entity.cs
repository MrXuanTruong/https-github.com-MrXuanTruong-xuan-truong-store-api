using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    public abstract class Entity
    {
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }

        //[ForeignKey("CreatedBy")]
        //public Account CreatedAccount { get; set; }

        //[ForeignKey("UpdatedBy")]
        //public Account UpdatedAccount { get; set; }
    }
}
