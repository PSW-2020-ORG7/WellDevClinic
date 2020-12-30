using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;

namespace PSW_Pharmacy_Adapter.Service
{
    public class EmailService
    {
        public static MailMessage createMail(string from, string to, string cc, string bcc, string subject, string body, bool isHtml)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(from);
            mailMessage.To.Add(new MailAddress(to));
            mailMessage.Subject = subject;
            if (bcc != null && bcc != "")
                mailMessage.Bcc.Add(new MailAddress(bcc));
            if (cc != null && cc != "")
                mailMessage.CC.Add(new MailAddress(cc));
            mailMessage.Body = body;
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = isHtml;

            return mailMessage;
        }
        public static void sendMail(MailMessage mailMessage)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("integration.adapter@gmail.com", "adapter12!");
            smtpClient.Send(mailMessage);
        }

    }
}
