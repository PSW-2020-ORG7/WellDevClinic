using PSW_Pharmacy_Adapter.Tender_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Tender_Microservice.Repository.Iabstract;
using System.Collections.Generic;
using System.Net.Mail;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.ApplicationServices
{
    public class PharmacyEmailsService : IPharmacyEmailsService
    {
        private readonly IPharmacyEmailsRepository _emailRepo;
        private readonly ITenderOfferService _tenderOfferService;

        public PharmacyEmailsService(IPharmacyEmailsRepository pharmacyEmailsRepository, ITenderOfferService tenderOfferService)
        {
            _emailRepo = pharmacyEmailsRepository;
            _tenderOfferService = tenderOfferService;
        }
        public PharmacyEmails AddEmail(PharmacyEmails email)
            => _emailRepo.Save(email);

        public List<PharmacyEmails> GetAllEmails()
            => (List<PharmacyEmails>)_emailRepo.GetAll();

        public MailMessage createMail(string from, string to, string cc, string bcc, string subject, string body, bool isHtml)
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
        public void sendMail(MailMessage mailMessage)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("integration.adapter@gmail.com", "adapter12!");
            smtpClient.Send(mailMessage);
        }

        public void sendEmailToAllEmails()
        {
            foreach(PharmacyEmails Emails in GetAllEmails())
            {
                MailMessage mailMessage = createMail("integration.adapter@gmail.com", Emails.Mail.Mail, "", "", "Posetite nas da biste videli nove tendere", "Posetite nas da biste videli nove tendere", false);
                sendMail(mailMessage);
            }
        }
        public bool sendEmailToWinner(long id)
        {
            TenderOffer offer = _tenderOfferService.GetOffer(id);
            if (offer == null)
                return false;
            MailMessage mailMessage = createMail("integration.adapter@gmail.com", offer.Mail.Mail, "", "", "Pobedili ste!", "Vi ste pobednik tendera, molimo vas da nam posaljete lekove u najkracem mogucem roku!", false);
            sendMail(mailMessage);
            return true;
        }
    }
}
