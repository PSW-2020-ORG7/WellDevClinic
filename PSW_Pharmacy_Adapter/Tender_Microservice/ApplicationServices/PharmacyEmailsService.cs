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

        private const string HOSPITAL_EMAIL = "integration.adapter@gmail.com";
        private const string HOSPITAL_EMAIL_PASS = "adapter12!";

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
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body,
                Priority = MailPriority.Normal,
                SubjectEncoding = System.Text.Encoding.UTF8,
                BodyEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = isHtml
            };
            mailMessage.To.Add(new MailAddress(to));
            if (bcc != null && bcc != "")
                mailMessage.Bcc.Add(new MailAddress(bcc));
            if (cc != null && cc != "")
                mailMessage.CC.Add(new MailAddress(cc));

            return mailMessage;
        }
        public void sendMail(MailMessage mailMessage)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(HOSPITAL_EMAIL, HOSPITAL_EMAIL_PASS)
            };
            smtpClient.Send(mailMessage);
        }

        public void sendEmailToAllEmails()
        {
            foreach(PharmacyEmails Emails in GetAllEmails())
            {
                MailMessage mailMessage = createMail(HOSPITAL_EMAIL, Emails.Mail.Mail, "", "", "New tender", "We have just created new tender. Check it out: http://localhost:64724/viewTenders.html", false);
                sendMail(mailMessage);
            }
        }
        public bool sendEmailToWinner(long id)
        {
            TenderOffer offer = _tenderOfferService.GetOffer(id);
            if (offer == null)
                return false;
            MailMessage mailMessage = createMail(HOSPITAL_EMAIL, offer.Mail.Mail, "", "", "You win!", "You have been choosen as a tender winner for tender with id: " + offer.TenderId + ". We have sent you our order", false);
            sendMail(mailMessage);
            return true;
        }
    }
}
