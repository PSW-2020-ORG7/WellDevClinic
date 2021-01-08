using PSW_Pharmacy_Adapter.Model.Pharmacy;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

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


    }
}
