using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Operator
{
    public class OperatorRequestModel
    {
        public long Id { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string StatusId { get; set; }
        public string Password { get; set; }
        public string Address { get; internal set; }
        public string AccountTypeId { get; internal set; }
    }
}
