using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("Accounts")]
    public class Account : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public AccountType AccountType { get; set; }

        [StringLength(50)]
        public string BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }
}
