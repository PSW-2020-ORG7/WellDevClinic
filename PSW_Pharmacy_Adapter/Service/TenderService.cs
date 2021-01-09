using PSW_Pharmacy_Adapter.Model.Pharmacy;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Service
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepo;

        public TenderService(ITenderRepository tenderRepository)
        {
            _tenderRepo = tenderRepository;
        }

        public Tender AddTender(Tender tender)
            => _tenderRepo.Save(tender);

        public List<Tender> GetAllTenders()
            => (List<Tender>)_tenderRepo.GetAll();

        public Tender GetTender(long id)
            => _tenderRepo.Get(id);

        
    }
}
