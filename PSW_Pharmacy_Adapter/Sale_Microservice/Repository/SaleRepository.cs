using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Sale_Microservice.Repository.Iabstract;
using System.Collections.Generic;
using System.Linq;

namespace PSW_Pharmacy_Adapter.Sale_Microservice.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly MyDbContext _dbContext;

        public SaleRepository(MyDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public Sale Get(long id)
            => _dbContext.Sales.FirstOrDefault(sale => sale.Id == id);

        public IEnumerable<Sale> GetAll()
        {
            List<Sale> sales = new List<Sale>();
            _dbContext.Sales.ToList().ForEach(s => sales.Add(s));
            return sales;
        }

        public bool Exists(long id) => Get(id) != null;

        public bool Delete(long id)
        {
            Sale sale = _dbContext.Sales.SingleOrDefault(s => s.Id == id);
            if (sale != null)
            {
                _dbContext.Sales.Remove(sale);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Sale Save(Sale entity)
        {
            Sale sale = _dbContext.Sales.SingleOrDefault(s => s.Id == entity.Id);
            if (sale == null)
            {
                _dbContext.Sales.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            return null;
        }

        public Sale Update(Sale entity)
        {
            Sale sale = _dbContext.Sales.SingleOrDefault(s => s.Id == entity.Id);
            if (sale != null)
            {
                _dbContext.Sales.Update(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            return null;
        }
    }
}
