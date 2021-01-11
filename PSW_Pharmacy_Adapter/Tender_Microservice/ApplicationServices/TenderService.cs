using PSW_Pharmacy_Adapter.Tender_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Tender_Microservice.Repository.Iabstract;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.ApplicationServices
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

        public void SendEmail(long id)
            => _emailsService.sendEmailToWinner(id);

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

        public List<Medication> GetTenderMedications(long id)
            => _tenderRepo.GetMedications(id);
			
		public Tender UpdateWinner(long idWinner)
            => _tenderRepo.UpdateWinner(idWinner);

        public Tender DeleteTender(long id)
            => _tenderRepo.DeleteTenderLogicaly(id);
    }
}
