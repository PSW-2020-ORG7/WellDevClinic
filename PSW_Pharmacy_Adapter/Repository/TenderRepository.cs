using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Model.Pharmacy;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using System.Collections.Generic;
using System.Linq;

namespace PSW_Pharmacy_Adapter.Repository
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
        {
            throw new System.NotImplementedException();
        }

        public Tender Get(long id)
         => _dbContext.Tender.FirstOrDefault(tender => tender.Id == id);

        public IEnumerable<Tender> GetAll()
        {
            List<Tender> tenders = new List<Tender>();
            _dbContext.Tender.ToList().ForEach(t => tenders.Add(t));
            return tenders;
        }

        public Tender Save(Tender ten)
        {
            Tender tender = _dbContext.Tender.SingleOrDefault(t => t.Id == ten.Id);
            if (tender == null)
            {
                _dbContext.Tender.Add(ten);
                _dbContext.SaveChanges();
                return ten;
            }
            return null;
        }


        public Tender Update(Tender entity)
        {
            throw new System.NotImplementedException();
        }


        public List<Medication> GetMedications(long tenderId) {
            Tender tender = _dbContext.Tender.SingleOrDefault(t => t.Id == tenderId);
            return tender.Medications;
        }
		
		public Tender UpdateWinner(long idWinner)
        {
            TenderOffer offer= _dbContext.TenderOffers.SingleOrDefault(o => o.Id == idWinner);
            Tender tender1 = _dbContext.Tender.SingleOrDefault(t => t.Id == offer.TenderId);
            tender1.OfferWinner = idWinner;
            if (tender1 != null)
            {
                _dbContext.Tender.Update(tender1);
                _dbContext.SaveChanges();
                return tender1;
            }
            return null;
        }

        public Tender DeleteTender(long id) {
            Tender tender = _dbContext.Tender.SingleOrDefault(t => t.Id == id);
            tender.IsDeleted = true;
            if (tender != null)
            {
                _dbContext.Tender.Update(tender);
                _dbContext.SaveChanges();
                return tender;
            }
            return null;
        }
    }
}
