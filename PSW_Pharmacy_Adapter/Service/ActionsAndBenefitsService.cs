using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository;
using PSW_Pharmacy_Adapter.Repository.Iabstract;

namespace PSW_Pharmacy_Adapter.Service
{
    public class ActionsAndBenefitsService
    {
        private readonly IActionAndBenefitRepository _ActionRepository;

        public ActionsAndBenefitsService(MyDbContext dbContext)
        {
            _ActionRepository = new ActionAndBenefitRepository(dbContext);
        }

        public ActionAndBenefit GetBenefit(long id) =>
            _ActionRepository.Get(id);

        public IEnumerable<ActionAndBenefit> GetAll() =>
            _ActionRepository.GetAll();

        public bool DeleteBenefit(long id) =>
            _ActionRepository.Delete(id);
    }
}
