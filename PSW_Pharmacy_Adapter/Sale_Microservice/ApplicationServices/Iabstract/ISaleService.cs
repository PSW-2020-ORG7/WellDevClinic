using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Sale_Microservice.ApplicationServices
{
    public interface ISaleService
    {
        public Sale GetBenefit(long id);

        public IEnumerable<Sale> GetAll();

        public bool DeleteBenefit(long id);

        public Sale UpdateStatus(long id, int status);

        public void DeleteExpiredAction();
    }
}
