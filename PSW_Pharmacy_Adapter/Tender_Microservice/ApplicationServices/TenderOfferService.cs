using PSW_Pharmacy_Adapter.Tender_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Tender_Microservice.Repository.Iabstract;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.ApplicationServices
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

        public List<TenderOffer> GetTenderOffers(long id)
        {
            List<TenderOffer> offers = new List<TenderOffer>();
            foreach (TenderOffer offer in _tenderRepo.GetAll())
                if (offer.TenderId.Equals(id))
                    offers.Add(offer);
                return offers;
        }

        public bool DeleteTenderOffer(long id)
            => _tenderRepo.Delete(id);

        public TenderOffer GetOffer(long id)
            => _tenderRepo.Get(id);
    }
}
