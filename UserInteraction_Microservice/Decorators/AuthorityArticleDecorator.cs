using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Decorators
{
    public class AuthorityArticleDecorator : IArticleAppService
    {
        private IArticleAppService _articleAppService;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;
        public AuthorityArticleDecorator(IArticleAppService articleAppService, string role)
        {
            _articleAppService = articleAppService;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<String>() { "Director", "Doctor" };
            AuthorizedUsers["Edit"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Get"] = new List<String>() { "Director", "Doctor", "Secretary", "Patient" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Director", "Doctor", "Secretary", "Patient" };
            AuthorizedUsers["Save"] = new List<String>() { "Doctor" };
        }

        public void Delete(Article entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                _articleAppService.Delete(entity);
        }

        public void Edit(Article entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                _articleAppService.Edit(entity);
        }

        public Article Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return _articleAppService.Get(id);
            else
                return null;
        }

        public IEnumerable<Article> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return _articleAppService.GetAll();
            else
                return null;
        }

        public Article Save(Article entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return _articleAppService.Save(entity);
            else
                return null;
        }
    }
}
