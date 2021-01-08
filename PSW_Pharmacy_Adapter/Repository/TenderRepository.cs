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
            throw new System.NotImplementedException();
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
    }
}
