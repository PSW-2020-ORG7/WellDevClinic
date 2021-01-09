using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using System;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Service
{
    public class PharmacyEmailsService : IPharmacyEmailsService
    {
        private readonly IPharmacyEmailsRepository _emailRepo;

        public PharmacyEmailsService(IPharmacyEmailsRepository pharmacyEmailsRepository)
        {
            _emailRepo = pharmacyEmailsRepository;
        }
        public PharmacyEmails AddEmail(PharmacyEmails email)
            => _emailRepo.Save(email);

        public List<PharmacyEmails> GetAllEmails()
            => (List<PharmacyEmails>)_emailRepo.GetAll();
    }
}
