using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;

namespace PSW_Pharmacy_Adapter.Service
{
    public class ActionsAndBenefitsService : IActionsAndBenefitsService
    {
        private readonly IActionAndBenefitRepository _ActionRepository;

        public ActionsAndBenefitsService(IActionAndBenefitRepository actionAndBenefitRepository)
        {
            _ActionRepository = actionAndBenefitRepository;
        }

        public ActionAndBenefit GetBenefit(long id)
            => _ActionRepository.Get(id);

        public IEnumerable<ActionAndBenefit> GetAll()
            => _ActionRepository.GetAll();

        public bool DeleteBenefit(long id)
            => _ActionRepository.Delete(id);
    }
}
