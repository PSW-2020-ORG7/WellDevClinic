using PSW_Pharmacy_Adapter.Model;
using System.Collections.Generic;
using System.Net.Mail;

namespace PSW_Pharmacy_Adapter.Service.Iabstract
{
    public interface IPharmacyEmailsService
    {
        public List<PharmacyEmails> GetAllEmails();
        public PharmacyEmails AddEmail(PharmacyEmails email);
        public void sendEmailToAllEmails();
        public MailMessage createMail(string from, string to, string cc, string bcc, string subject, string body, bool isHtml);
        public void sendMail(MailMessage mailMessage);
    }
}
