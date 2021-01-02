using DrugManipulation_Microservice.ApplicationServices.Abstract;
using DrugManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugManipulation_Microservice.Decorators
{
    public class AuthorityDrugDecorator
    {
        private readonly IDrugAppService _drugAppService;
        private String Role { get; set; }
        private readonly Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityDrugDecorator(IDrugAppService drugAppService)
        {
            _drugAppService = drugAppService;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Delete"] = new List<String>() { "Director", "Doctor" },
                ["Edit"] = new List<String>() { "Doctor" },
                ["Get"] = new List<String>() { "Director", "Doctor"},
                ["GetAll"] = new List<String>() { "Director", "Doctor"},
                ["Save"] = new List<String>() { "Director" },
                ["GetNotApprovedDrugs"] = new List<String>() { "Doctor" }
            };
        }
        public void Delete(Drug entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                _drugAppService.Delete(entity);
        }

        public void Edit(Drug entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                _drugAppService.Edit(entity);
        }

        public Drug Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _drugAppService.Get(id);
            return null;
        }

        public IEnumerable<Drug> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _drugAppService.GetAll();
            return null;
        }
        public List<Drug> GetNotApprovedDrugs()
        {
            if (AuthorizedUsers["GetNotApprovedDrugs"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _drugAppService.GetNotApprovedDrugs();
            return null;
        }
    }
}
