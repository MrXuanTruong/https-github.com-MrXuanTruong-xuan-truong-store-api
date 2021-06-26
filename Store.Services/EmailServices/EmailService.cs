using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.EmailServices
{
    public class EmailService: IEmailService
    {
        private readonly EmailServiceOptions _options;
        private readonly ILogger<EmailService> _logger;

        public EmailService(
            IOptions<EmailServiceOptions>  options,
            ILogger<EmailService> logger)
        {
            _options = options.Value;
            _logger = logger;
        }

        public async Task<bool> Send(
            string subject, 
            string body,
            string aliasName,
            List<string> toEmails, 
            List<string> ccEmails = null, 
            List<string> bccEmails = null)
        {
            using (var client = new SmtpClient(_options.Host, _options.Port))
            {
                client.EnableSsl = _options.EnableSsl;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_options.Username, _options.Password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                ServicePointManager.ServerCertificateValidationCallback =
                delegate (
                    object s,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors
                )
                {
                    return true;
                };

                if (string.IsNullOrEmpty(aliasName))
                {
                    aliasName = _options.Alias;
                }

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_options.Email, aliasName);

                foreach (var email in toEmails)
                {
                    mailMessage.To.Add(email);
                }

                if (ccEmails != null)
                {
                    foreach (var email in ccEmails)
                    {
                        mailMessage.CC.Add(email);
                    }
                }

                if (bccEmails != null)
                {
                    foreach (var email in bccEmails)
                    {
                        mailMessage.Bcc.Add(email);
                    }
                }

                mailMessage.Body = body;
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                try
                {
                    client.Send(mailMessage);
                    return true;
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, this.GetType().Name);
                    return false;
                }
            }
        }
        public async Task<bool> SendByConfigurationData(EmailServiceOptions options,string to, string subject = "", string body = "", string[] cc = null, string[] bcc = null)
        {
            var mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = true;
            if (cc != null)
            {
                foreach (var item in cc)
                {
                    mailMessage.CC.Add(item);
                }
            }

            if (bcc != null)
            {
                foreach (var item in bcc)
                {
                    mailMessage.Bcc.Add(item);
                }
            }

            var emails = to.Split(';');
            foreach (var email in emails)
            {
                if (!string.IsNullOrEmpty(email))
                {
                    mailMessage.To.Add(email);
                }
            }

            mailMessage.Subject = subject;
            mailMessage.Body = body;

            try
            {
                mailMessage.From = new MailAddress(options.Email, options.Alias);

                var senderUserName = options.Username;
                if (string.IsNullOrEmpty(senderUserName))
                    senderUserName = options.Email;

                var smtpClient = new
                    SmtpClient(options.Host, options.Port)
                {
                    Credentials =
                                             new System.Net.NetworkCredential(senderUserName,
                                                                              options.Password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = options.EnableSsl
                };

                await smtpClient.SendMailAsync(mailMessage);

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.GetType().Name);
                return false;
            }
        }
    }
}
