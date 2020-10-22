using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Operator
{
    public class OperatorItemModel
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string StatusId { get; set; }
        public string Password { get; set; }
        public string AccountTypeId { get; set; }
    }
}
