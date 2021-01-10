using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Model.Pharmacy;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Service
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepo;
        private readonly IPharmacyEmailsService _emailsService;
        public TenderService(ITenderRepository tenderRepository, IPharmacyEmailsService pharmacyEmailsService)
        {
            _tenderRepo = tenderRepository;
            _emailsService = pharmacyEmailsService;
        }

        public Tender AddTender(Tender tender)
        {
            Tender tender1= _tenderRepo.Save(tender);
            _emailsService.sendEmailToAllEmails();
            return tender1;
        }
        public List<Tender> GetAllTenders()
            => (List<Tender>)_tenderRepo.GetAll();

        public Tender GetTender(long id)
            => _tenderRepo.Get(id);

        public List<Medication> GetTenderMedications(long tenderId)
            => _tenderRepo.GetMedications(tenderId);
    }
}
