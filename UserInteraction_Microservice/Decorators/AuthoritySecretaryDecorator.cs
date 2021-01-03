using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Decorators
{
    public class AuthoritySecretaryDecorator : ISecretaryAppService
    {
        private readonly ISecretaryAppService _secretaryAppService;
        private String Role { get; set; }

        private readonly Dictionary<String, List<String>> AuthorizedUsers;

        public AuthoritySecretaryDecorator(ISecretaryAppService secretaryAppService)
        {
            this._secretaryAppService = secretaryAppService;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Delete"] = new List<string>() { "Secretary" },
                ["Edit"] = new List<string>() { "Secretary" },
                ["Get"] = new List<string>() { "Secretary" },
                ["GetAll"] = new List<string>() { "Secretary", "Patient" },
                ["Save"] = new List<string>() { "Secretary" },
                ["GetAllEager"] = new List<string>() { "Secretary" },
                ["GetEager"] = new List<string>() { "Secretary" },
                ["LogIn"] = new List<string>() { "Secretary" }
            };

        }

        public void Delete(Secretary entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                _secretaryAppService.Delete(entity);
        }

        public void Edit(Secretary entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                _secretaryAppService.Edit(entity);
        }

        public Secretary Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _secretaryAppService.Get(id);
            return null;
        }

        public IEnumerable<Secretary> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _secretaryAppService.GetAll();
            return null;
        }

        public IEnumerable<Secretary> GetAllEager()
        {
            if (AuthorizedUsers["GetAllEager"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _secretaryAppService.GetAllEager();
            return null;
        }

        public Secretary GetEager(long id)
        {
            if (AuthorizedUsers["GetEager"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _secretaryAppService.GetEager(id);
            return null;
        }

        public Secretary LogIn(string username, string password)
        {
            return _secretaryAppService.LogIn(username, password);
        }

        public Secretary Save(Secretary entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _secretaryAppService.Save(entity);
            return null;
        }
    }
}
