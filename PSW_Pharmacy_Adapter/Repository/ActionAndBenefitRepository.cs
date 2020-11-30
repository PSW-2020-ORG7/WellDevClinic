using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Repository
{
    public class ActionAndBenefitRepository : IActionAndBenefitRepository
    {
        private readonly MyDbContext myDbContext;

        public ActionAndBenefitRepository(MyDbContext DbContext)
        {

            myDbContext = DbContext;
        }
        public bool Delete(long id)
        {
            ActionAndBenefit a = myDbContext.ActionsAndBenefits.SingleOrDefault(a => a.Id == id);
            if (a != null)
            {
                myDbContext.ActionsAndBenefits.Remove(a);
                myDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public ActionAndBenefit Get(long id) 
            => myDbContext.ActionsAndBenefits.FirstOrDefault(action => action.Id == id);

        public List<ActionAndBenefit> GetAll()
        {
            List<ActionAndBenefit> actions = new List<ActionAndBenefit>();
            myDbContext.ActionsAndBenefits.ToList().ForEach(a => actions.Add(a));
            return actions;
        }

        public bool Save(ActionAndBenefit action)
        {
            ActionAndBenefit a = myDbContext.ActionsAndBenefits.SingleOrDefault(a => a.Id == action.Id);
            if (a == null)
            {
                myDbContext.ActionsAndBenefits.Add(action);
                myDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
