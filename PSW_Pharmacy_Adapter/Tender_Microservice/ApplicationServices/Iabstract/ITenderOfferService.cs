using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.ApplicationServices.Iabstract
{
    public interface ITenderOfferService
    {
        public TenderOffer AddOffer(TenderOffer offer);

        public List<TenderOffer> GetTenderOffers(long id);
        public bool DeleteTenderOffer(long id);
        public TenderOffer GetOffer(long id);
    }
}
