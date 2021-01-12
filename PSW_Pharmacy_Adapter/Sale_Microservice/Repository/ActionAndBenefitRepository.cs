using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Sale_Microservice.Repository.Iabstract;
using System.Collections.Generic;
using System.Linq;

namespace PSW_Pharmacy_Adapter.Sale_Microservice.Repository
{
    public class ActionAndBenefitRepository : IActionAndBenefitRepository
    {
        private readonly MyDbContext _dbContext;

        public ActionAndBenefitRepository(MyDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public ActionAndBenefit Get(long id)
            => _dbContext.ActionsAndBenefits.FirstOrDefault(action => action.Id == id);

        public IEnumerable<ActionAndBenefit> GetAll()
        {
            List<ActionAndBenefit> actions = new List<ActionAndBenefit>();
            _dbContext.ActionsAndBenefits.ToList().ForEach(a => actions.Add(a));
            return actions;
        }

        public bool Exists(long id) => Get(id) != null;

        public bool Delete(long id)
        {
            ActionAndBenefit a = _dbContext.ActionsAndBenefits.SingleOrDefault(a => a.Id == id);
            if (a != null)
            {
                _dbContext.ActionsAndBenefits.Remove(a);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public ActionAndBenefit Save(ActionAndBenefit entity)
        {
            ActionAndBenefit a = _dbContext.ActionsAndBenefits.SingleOrDefault(a => a.Id == entity.Id);
            if (a == null)
            {
                _dbContext.ActionsAndBenefits.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            return null;
        }

        public ActionAndBenefit Update(ActionAndBenefit entity)
        {
            ActionAndBenefit a = _dbContext.ActionsAndBenefits.SingleOrDefault(a => a.Id == entity.Id);
            if (a != null)
            {
                _dbContext.ActionsAndBenefits.Update(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            return null;
        }
    }
}
