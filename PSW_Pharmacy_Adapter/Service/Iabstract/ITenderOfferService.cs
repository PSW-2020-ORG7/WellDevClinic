using PSW_Pharmacy_Adapter.Model.Pharmacy;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Service.Iabstract
{
    public interface ITenderOfferService
    {
        public TenderOffer AddOffer(TenderOffer offer);

        public List<TenderOffer> GetTenderOffers(long id);

        public void DeleteTenderOffer(long id);
    }
}
