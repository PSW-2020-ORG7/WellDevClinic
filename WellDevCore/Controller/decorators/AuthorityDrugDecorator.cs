using Model.PatientSecretary;
using System.Collections.Generic;
using System.Linq;

namespace bolnica.Controller.decorators
{
    public class AuthorityDrugDecorator : IDrugController
    {
        private IDrugController DrugController;
        private string Role;
        private Dictionary<string, List<string>> AuthorizedUsers;

        public AuthorityDrugDecorator(IDrugController drugController, string role)
        {
            DrugController = drugController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["ApproveDrug"] = new List<string>() { "Doctor" },
                ["CheckDrugNameUnique"] = new List<string>() { "Director" },
                ["Delete"] = new List<string>() { "Director" },
                ["Edit"] = new List<string>() { "Director", "Doctor" },
                ["Get"] = new List<string>() { "Director", "Doctor" },
                ["GetAll"] = new List<string>() { "Director", "Doctor" },
                ["GetNotApprovedDrugs"] = new List<string>() { "Doctor" },
                ["Save"] = new List<string>() { "Director" }
            };
        }

        public bool CheckDrugNameUnique(string name)
        {
            if (AuthorizedUsers["CheckDrugNameUnique"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DrugController.CheckDrugNameUnique(name);
            return false;
        }

        public void Delete(Drug entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                DrugController.Delete(entity);
        }

        public void Edit(Drug entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                DrugController.Edit(entity);
        }

        public Drug Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DrugController.Get(id);
            return null;
        }

        public IEnumerable<Drug> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DrugController.GetAll();
            return null;
        }

        public List<Drug> GetNotApprovedDrugs()
        {
            if (AuthorizedUsers["GetNotApprovedDrugs"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DrugController.GetNotApprovedDrugs();
            return null;
        }

        public Drug Save(Drug entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DrugController.Save(entity);
            return null;
        }
    }
}
