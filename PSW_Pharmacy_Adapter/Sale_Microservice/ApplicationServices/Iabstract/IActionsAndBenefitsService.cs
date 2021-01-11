using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Sale_Microservice.ApplicationServices
{
    public interface IActionsAndBenefitsService
    {
        public ActionAndBenefit GetBenefit(long id);

        public IEnumerable<ActionAndBenefit> GetAll();

        public bool DeleteBenefit(long id);

        public ActionAndBenefit UpdateStatus(long id, int status);

        public void DeleteExpiredAction();
    }
}
