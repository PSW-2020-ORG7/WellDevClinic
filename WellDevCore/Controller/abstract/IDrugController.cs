using Controller;
using Model.PatientSecretary;
using System.Collections.Generic;

namespace bolnica.Controller
{
    public interface IDrugController : IController<Drug,long>
    {
        bool CheckDrugNameUnique(string name);
        List<Drug> GetNotApprovedDrugs();
    }
}
