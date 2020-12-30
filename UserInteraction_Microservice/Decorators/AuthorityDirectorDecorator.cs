using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Decorators
{
    public class AuthorityDirectorDecorator : IDirectorAppService
    {
        private readonly IDirectorAppService _directorAppService;
        private readonly String Role;
        private readonly Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityDirectorDecorator(IDirectorAppService directorAppService, String role)
        {
            this._directorAppService = directorAppService;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Delete"] = new List<string>() { "Director" },
                ["Edit"] = new List<string>() { "Director" },
                ["Get"] = new List<string>() { "Director" },
                ["GetAll"] = new List<string>() { "Director" },
                ["Save"] = new List<string>() { "Director" },
                ["GetAllEager"] = new List<string>() { "Director" },
                ["GetEager"] = new List<string>() { "Director" }
            };
        }

        public void Delete(Director entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                _directorAppService.Delete(entity);
        }

        public void Edit(Director entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                _directorAppService.Edit(entity);
        }

        public Director Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _directorAppService.Get(id);
            return null;
        }

        public IEnumerable<Director> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _directorAppService.GetAll();
            return null;
        }

        public IEnumerable<Director> GetAllEager()
        {
            if (AuthorizedUsers["GetAllEager"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _directorAppService.GetAllEager();
            return null;
        }

        public Director GetEager(long id)
        {
            if (AuthorizedUsers["GetEager"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _directorAppService.GetEager(id);
            return null;
        }

        public Director LogIn(string username, string password)
        {
            return _directorAppService.LogIn(username, password);
        }

        public Director Save(Director entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _directorAppService.Save(entity);
            return null;
        }
    }

}