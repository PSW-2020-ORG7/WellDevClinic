using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchAndSchedule_Microservice.Decorators
{
    public class AuthorityBussinesDayDecorator
    {
        private readonly IBussinesDayAppService _bussinesDayAppService;
        private String Role { get; set; }

        private readonly Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityBussinesDayDecorator(IBussinesDayAppService bussinesDayAppService)
        {
            this._bussinesDayAppService = bussinesDayAppService;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Delete"] = new List<string>() { "Director" },
                ["Edit"] = new List<string>() { "Director" },
                ["Get"] = new List<string>() { "Director", "Doctor"},
                ["GetAll"] = new List<string>() { "Director"},
                ["Save"] = new List<string>() { "Director" },



            /*["FreePeriod"] = new List<string>() { "Doctor", "Secretary", "Patient" };
            ["GetBusinessDaysByDoctor"] = new List<string>() { "Director" };
            ["GetExactDay"] = new List<string>() { "Doctor", "Secretary", "Patient" };
            ["isExaminationPossible"] = new List<string>() { "Secretary" };
            ["MarkAsOccupied"] = new List<string>() { "Doctor", "Patient", "Secretary" };
            ["Search"] = new List<string>() { "Doctor", "Secretary", "Patient" };
            ["ChangeDoctorShift"] = new List<string>() { "Director" };
            */
             };

        }
        public void Delete(BussinesDay entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                _bussinesDayAppService.Delete(entity);
        }

        public void Edit(BussinesDay entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                _bussinesDayAppService.Edit(entity);
        }

        public BussinesDay Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _bussinesDayAppService.Get(id);
            return null;
        }

        public IEnumerable<BussinesDay> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _bussinesDayAppService.GetAll();
            return null;
        }
        public BussinesDay Save(BussinesDay entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _bussinesDayAppService.Save(entity);
            return null;
        }
    }
}
