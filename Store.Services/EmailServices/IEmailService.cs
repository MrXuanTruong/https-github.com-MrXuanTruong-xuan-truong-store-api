using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.EmailServices
{
    public interface IEmailService
    {
        Task<bool> Send(string subject, string body, string aliasName, List<string> toEmails, List<string> ccEmails = null, List<string> bccEmails = null);
        Task<bool> SendByConfigurationData(EmailServiceOptions options, string to, string subject = "", string body = "", string[] cc = null, string[] bcc = null);
    }
}
