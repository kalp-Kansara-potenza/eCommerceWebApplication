using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class util
    {
        private IConfiguration config { get; }
        public util(IConfiguration myConfig)
        {
            config = myConfig;
        }
        //public string subject;
        //public string messagebody;
        //public string tomail;

        public void sendEmail(string subject, string messagebody, string tomail)
            {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(config["smtp:smtpmail_id"]);
                message.To.Add(new MailAddress(tomail));
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = messagebody;
                smtp.Port = Convert.ToInt32(config["smtp:smtp_port"]);
                smtp.Host = config["smtp:smtp_host"];
                smtp.EnableSsl = Convert.ToBoolean(config["smtp:smtp_enableSSL"]);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(config["smtp:smtpmail_id"], config["smtp:smtpmail_password"]);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}
