using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Decorators
{
    public  class AuthorityFeedbackDecorator : IFeedbackAppService
    {
        private readonly IFeedbackAppService _feedbackAppService;
        private readonly String Role;
        private readonly Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityFeedbackDecorator(IFeedbackAppService feedbackAppService, string role)
        {
            _feedbackAppService = feedbackAppService;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Delete"] = new List<String>() { "Director", "Patient" },
                ["Edit"] = new List<String>() { "Patient", "Director" },
                ["Get"] = new List<String>() { "Director", "Doctor", "Secretary", "Patient" },
                ["GetAll"] = new List<String>() { "Director", "Doctor", "Secretary", "Patient" },
                ["Save"] = new List<String>() { "Patient" }
            };
        }

        public void Delete(Feedback entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                _feedbackAppService.Delete(entity);
        }

        public void Edit(Feedback entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                _feedbackAppService.Edit(entity);
        }

        public Feedback Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return _feedbackAppService.Get(id);
            return null;
        }

        public IEnumerable<Feedback> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return _feedbackAppService.GetAll();
            return null;
        }

        public Feedback Save(Feedback entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return _feedbackAppService.Save(entity);
            return null;
        }
    }
}
