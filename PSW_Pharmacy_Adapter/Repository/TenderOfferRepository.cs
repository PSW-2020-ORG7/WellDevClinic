using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Model.Pharmacy;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using System.Collections.Generic;
using System.Linq;

namespace PSW_Pharmacy_Adapter.Repository
{
    public class TenderOfferRepository : ITenderOfferRepository
    {
        private readonly MyDbContext _dbContext;

        public TenderOfferRepository(MyDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public bool Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new System.NotImplementedException();
        }

        public TenderOffer Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TenderOffer> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TenderOffer Save(TenderOffer offer)
        {
            TenderOffer tender = _dbContext.TenderOffers.SingleOrDefault(t => t.Id == offer.Id);
            if (tender == null)
            {
                _dbContext.TenderOffers.Add(offer);
                _dbContext.SaveChanges();
                return offer;
            }
            return null;
        }

        public TenderOffer Update(TenderOffer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
