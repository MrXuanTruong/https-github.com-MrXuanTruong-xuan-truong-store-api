using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Services.EmailServices
{
    public class EmailServiceOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public string Alias { get; set; }
    }
}
