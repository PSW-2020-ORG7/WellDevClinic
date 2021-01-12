using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Tender_Microservice.Repository.Iabstract;
using System.Collections.Generic;
using System.Linq;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.Repository
{
    public class TenderRepository : ITenderRepository
    {
        private readonly MyDbContext _dbContext;

        public TenderRepository(MyDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public bool Delete(long id)
        {
            Tender tender = _dbContext.Tender.SingleOrDefault(ten => ten.Id == id);
            if (tender != null)
            {
                _dbContext.Tender.Remove(tender);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Exists(long id)
            => Get(id) != null;

        public Tender Get(long id)
         => _dbContext.Tender.FirstOrDefault(tender => tender.Id == id);

        public IEnumerable<Tender> GetAll()
        {
            List<Tender> tenders = new List<Tender>();
            _dbContext.Tender.ToList().ForEach(t => tenders.Add(t));
            return tenders;
        }

        public Tender Save(Tender entity)
        {
            Tender tender = _dbContext.Tender.SingleOrDefault(t => t.Id == entity.Id);
            if (tender == null)
            {
                _dbContext.Tender.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            return null;
        }


        public Tender Update(Tender entity)
        {
            Tender tender = _dbContext.Tender.SingleOrDefault(t => t.Id == entity.Id);
            if (tender != null)
            {
                _dbContext.Tender.Update(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            return null;
        }


        public List<Medication> GetMedications(long id)
            => _dbContext.Tender.SingleOrDefault(t => t.Id == id).Medications;
		
		public Tender UpdateWinner(long idWinner)
        {
            TenderOffer offer= _dbContext.TenderOffers.SingleOrDefault(o => o.Id == idWinner);
            Tender tender = _dbContext.Tender.SingleOrDefault(t => t.Id == offer.TenderId);
            if (tender != null)
            {
                tender.OfferWinner = idWinner;
                _dbContext.Tender.Update(tender);
                _dbContext.SaveChanges();
                return tender;
            }
            return null;
        }

        public Tender DeleteTenderLogicaly(long id) {
            Tender tender = _dbContext.Tender.SingleOrDefault(t => t.Id == id);
            if (tender != null)
            {
                tender.IsDeleted = true;
                _dbContext.Tender.Update(tender);
                _dbContext.SaveChanges();
                return tender;
            }
            return null;
        }
    }
}
