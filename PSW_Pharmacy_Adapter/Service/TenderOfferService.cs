using PSW_Pharmacy_Adapter.Model.Pharmacy;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using System;

namespace PSW_Pharmacy_Adapter.Service
{
    public class TenderOfferService : ITenderOfferService
    {
       private readonly ITenderOfferRepository _tenderRepo;

        public TenderOfferService(ITenderOfferRepository tenderOfferRepository)
        {
            _tenderRepo = tenderOfferRepository;
        }
        public TenderOffer AddOffer(TenderOffer offer)
            => _tenderRepo.Save(offer);
    }
}
