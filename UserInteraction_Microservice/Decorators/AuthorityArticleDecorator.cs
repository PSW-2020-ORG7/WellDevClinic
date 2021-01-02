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
        private readonly IArticleAppService _articleAppService;
        private String Role { get; set; }
        private readonly Dictionary<String, List<String>> AuthorizedUsers;
        public AuthorityArticleDecorator(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Delete"] = new List<String>() { "Director", "Doctor" },
                ["Edit"] = new List<String>() { "Doctor" },
                ["Get"] = new List<String>() { "Director", "Doctor", "Secretary", "Patient" },
                ["GetAll"] = new List<String>() { "Director", "Doctor", "Secretary", "Patient" },
                ["Save"] = new List<String>() { "Doctor" }
            };
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
