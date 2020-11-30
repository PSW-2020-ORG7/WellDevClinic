using PSW_Pharmacy_Adapter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Repository.Iabstract
{
    interface IActionAndBenefitRepository
    {
        public ActionAndBenefit Get(long id);
        public List<ActionAndBenefit> GetAll();
        public bool Save(ActionAndBenefit action);
        public bool Delete(long id);
    }
}
