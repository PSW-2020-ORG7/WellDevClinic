using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Tender_Microservice.Repository.Iabstract;
using System.Collections.Generic;
using System.Linq;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.Repository
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
            TenderOffer offer = _dbContext.TenderOffers.SingleOrDefault(offer => offer.Id == id);
            if (offer != null)
            {
                offer.Medications.Clear();
                _dbContext.TenderOffers.Remove(offer);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Exists(long id)
            => Get(id) != null;

        public TenderOffer Get(long id)
            => _dbContext.TenderOffers.FirstOrDefault(offer => offer.Id == id);

        public IEnumerable<TenderOffer> GetAll()
        {
            List<TenderOffer> offers = new List<TenderOffer>();
            _dbContext.TenderOffers.ToList().ForEach(o => offers.Add(o));
            return offers;
        }

        public TenderOffer Save(TenderOffer entity)
        {
            TenderOffer tender = _dbContext.TenderOffers.SingleOrDefault(t => t.Id == entity.Id);
            if (tender == null)
            {
                _dbContext.TenderOffers.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            return null;
        }

        public TenderOffer Update(TenderOffer entity)
        {
            TenderOffer tender = _dbContext.TenderOffers.SingleOrDefault(t => t.Id == entity.Id);
            if (tender != null)
            {
                _dbContext.TenderOffers.Update(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            return null;
        }
    }
}
