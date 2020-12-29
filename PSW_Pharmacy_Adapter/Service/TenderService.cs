using PSW_Pharmacy_Adapter.Model.Pharmacy;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using System;
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

        public List<Tender> GetAllTenders()
            => (List<Tender>)_tenderRepo.GetAll();

        
    }
}
