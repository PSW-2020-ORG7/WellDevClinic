using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchAndSchedule_Microservice.Decorators
{
    public class AuthorityExaminationDecorator
    {
        private readonly IExaminationAppService _examinationAppService;
        private String Role { get; set; }

        private readonly Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityExaminationDecorator(IExaminationAppService examinationAppService)
        {
            this._examinationAppService = examinationAppService;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Delete"] = new List<string>() { "Doctor", "Patient", "Secretary" },
                ["Edit"] = new List<string>() { "Secretary" },
                ["Get"] = new List<string>() { "Doctor", "Patient", "Secretary" },
                ["GetAll"] = new List<string>() { "Patient", "Secretary", "Doctor" },
                ["Save"] = new List<string>() { "Patient", "Secretary", "Doctor" },


            /*
            AuthorizedUsers["GetAllPrevious"] = new List<String>() { "Doctor", "Patient", "Secretary" };
            AuthorizedUsers["GetExaminationsByFilter"] = new List<String>() { "Secretary" };
            AuthorizedUsers["GetFinishedExaminationsByUser"] = new List<String>() { "Doctor" };
            AuthorizedUsers["GetUpcomingExaminationsByUser"] = new List<String>() { "Patient", "Doctor", "Director" };
            AuthorizedUsers["SaveFinishedExamination"] = new List<String>() { "Doctor" };
            */
             };

        }
        public void Delete(Examination entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                _examinationAppService.Delete(entity);
        }

        public void Edit(Examination entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                _examinationAppService.Edit(entity);
        }

        public Examination Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return _examinationAppService.Get(id);
            return null;
        }

        public IEnumerable<Examination> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return _examinationAppService.GetAll();
            return null;
        }

        public Examination Save(Examination entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return _examinationAppService.Save(entity);
            return null;
        }
    }
}
