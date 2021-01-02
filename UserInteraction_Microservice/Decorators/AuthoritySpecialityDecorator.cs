using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Decorators
{
    public class AuthoritySpecialityDecorator : ISpecialityAppService
    {
        private ISpecialityAppService _specialityAppService;
        private String Role { get; set; }
        private Dictionary<String, List<String>> AuthorizedUsers;
        public AuthoritySpecialityDecorator(ISpecialityAppService specialityAppService)
        {
            _specialityAppService = specialityAppService;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Get"] = new List<String>() { "Patient", "Doctor", "Director" },
                ["GetAll"] = new List<String>() { "Patient", "Doctor", "Director" },
                ["Save"] = new List<String>() { "Director" },
                ["Edit"] = new List<String>() { "Director" },
                ["Delete"] = new List<String>() { "Director" }
            };
        }


        public void Delete(Speciality entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                _specialityAppService.Delete(entity);

        }

        public void Edit(Speciality entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                _specialityAppService.Edit(entity);
        }

        public Speciality Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return _specialityAppService.Get(id);
            else
                return null;
        }

        public IEnumerable<Speciality> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return _specialityAppService.GetAll();
            else
                return null;
        }

        public Speciality Save(Speciality entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return _specialityAppService.Save(entity);
            else
                return null;
        }
    }
}
