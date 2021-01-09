using PSW_Pharmacy_Adapter.Model;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Service.Iabstract
{
    public interface IPharmacyEmailsService
    {
        public List<PharmacyEmails> GetAllEmails();
        public PharmacyEmails AddEmail(PharmacyEmails email);
        public void sendEmailToAllEmails();
    }
}
