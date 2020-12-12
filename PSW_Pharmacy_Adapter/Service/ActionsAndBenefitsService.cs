using System;
using System.Collections.Generic;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository;
using PSW_Pharmacy_Adapter.Repository.Iabstract;

namespace PSW_Pharmacy_Adapter.Service
{
    public class ActionsAndBenefitsService : IActionsAndBenefitsService
    {
        private readonly IActionAndBenefitRepository _actionRepository;

        public ActionsAndBenefitsService(IActionAndBenefitRepository actionAndBenefitRepo)
        {
            _actionRepository = actionAndBenefitRepo;
        }

        public ActionAndBenefit GetBenefit(long id) =>
            _actionRepository.Get(id);

        public IEnumerable<ActionAndBenefit> GetAll() =>
            _actionRepository.GetAll();

        public bool DeleteBenefit(long id) =>
            _actionRepository.Delete(id);

        public ActionAndBenefit UpdateStatus(long id, int stat) 
        {
            ActionAndBenefit action = _actionRepository.Get(id);
            switch (stat)
            {
                case 0:
                    action.Status = ActionStatus.pending;
                    break;
                case 1:
                    action.Status = ActionStatus.accepted;
                    break;
                case 2:
                    action.Status = ActionStatus.favourite;
                    break;
            }
            return _actionRepository.Update(action);
        }

        public void DeleteExpiredAction()
        {
            foreach (ActionAndBenefit action in GetAll())
            {
                if (action.EndDate < DateTime.Now)
                {
                    _actionRepository.Delete((long)action.Id);
                }
            }
        }

    }
}
