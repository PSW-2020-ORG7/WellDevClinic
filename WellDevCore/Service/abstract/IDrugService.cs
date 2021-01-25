using Model.PatientSecretary;
using Service;
using System.Collections.Generic;

namespace bolnica.Service
{
    public interface IDrugService : IService<Drug, long>
    {
        bool CheckDrugNameUnique(string name);
        List<Drug> GetNotApproved();
    }
}
