using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Controller;
using bolnica.Model.Users;

namespace bolnica.Controller.decorators
{
    public class AuthorityFeedbackDecorator : IFeedbackController
    {
        private IFeedbackController FeedbackController;
        public String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityFeedbackDecorator(IFeedbackController feedbackController, string role)
        {
            FeedbackController = feedbackController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<String>() { "Director"};
            AuthorizedUsers["Edit"] = new List<String>() { "Director" };
            AuthorizedUsers["Get"] = new List<String>() { "Director" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Director","Patient" };
            AuthorizedUsers["Save"] = new List<String>() { "Patient" };
        }

        public void Delete(Feedback entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                FeedbackController.Delete(entity);
        }

        public void Edit(Feedback entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                FeedbackController.Edit(entity);
        }

        public Feedback Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return FeedbackController.Get(id);
            else
                return null;
        }

        public IEnumerable<Feedback> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return FeedbackController.GetAll();
            else
                return null;
        }

        public Feedback Save(Feedback entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return FeedbackController.Save(entity);
            else
                return null;
        }
    }
}
