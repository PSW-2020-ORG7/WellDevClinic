using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.ApplicationServices.DTObjects;
using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchAndSchedule_Microservice.Decorators
{
    public class AuthorityBussinesDayDecorator : IBussinesDayAppService
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
                ["FreePeriod"] = new List<string>() { "Doctor", "Secretary", "Patient" },
                ["GetBusinessDaysByDoctor"] = new List<string>() { "Director" },
                ["GetExactDay"] = new List<string>() { "Doctor", "Secretary", "Patient" },
                ["IsExaminationPossible"] = new List<string>() { "Secretary" },
                ["MarkAsOccupied"] = new List<string>() { "Doctor", "Patient", "Secretary" },
                ["Search"] = new List<string>() { "Doctor", "Secretary", "Patient" },
                ["ChangeDoctorShift"] = new List<string>() { "Director" },
                ["DeleteBusinessDayByRoom"] = new List<string>() { "Director" }

            };

        }
        public void Delete(BusinessDay entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                _bussinesDayAppService.Delete(entity);
        }

        public void Edit(BusinessDay entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                _bussinesDayAppService.Edit(entity);
        }

        public BusinessDay Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _bussinesDayAppService.Get(id);
            return null;
        }

        public IEnumerable<BusinessDay> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _bussinesDayAppService.GetAll();
            return null;
        }
        public BusinessDay Save(BusinessDay entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _bussinesDayAppService.Save(entity);
            return null;
        }
        public void FreePeriod(BusinessDay businessDay, List<DateTime> period)
        {
            if (AuthorizedUsers["FreePeriod"].SingleOrDefault(any => any.Equals(Role)) != null)
                _bussinesDayAppService.FreePeriod(businessDay, period);

        }

        public List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor)
        {
            if (AuthorizedUsers["GetBusinessDaysByDoctor"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _bussinesDayAppService.GetBusinessDaysByDoctor(doctor);
            return null;
        }
        public BusinessDay GetExactDay(Doctor doctor, DateTime date)
        {
            if (AuthorizedUsers["GetExactDay"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _bussinesDayAppService.GetExactDay(doctor, date);
            return null;
        }

        public bool IsExaminationPossible(UpcomingExamination examination)
        {
            if (AuthorizedUsers["IsExaminationPossible"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _bussinesDayAppService.IsExaminationPossible(examination);
            return false;
        }

        public void MarkAsOccupied(List<Period> period, BusinessDay businessDay)
        {
            if (AuthorizedUsers["MarkAsOccupied"].SingleOrDefault(any => any.Equals(Role)) != null)
                _bussinesDayAppService.MarkAsOccupied(period, businessDay);
           
        }

        public List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO)
        {
            if(AuthorizedUsers["Search"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _bussinesDayAppService.Search(businessDayDTO);
            return null;
        }

        public bool ChangeDoctorShift(BusinessDay newShift)
        {

            if (AuthorizedUsers["ChangeDoctorShift"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _bussinesDayAppService.ChangeDoctorShift(newShift);
            return false;
        }

        public void DeleteBusinessDayByRoom(Room room)
        {
            if (AuthorizedUsers["DeleteBusinessDayByRoom"].SingleOrDefault(any => any.Equals(Role)) != null)
                _bussinesDayAppService.DeleteBusinessDayByRoom(room);
        }

        public void SetPriority(PriorityType priority)
        {
            _bussinesDayAppService.SetPriority(priority);
        }
    }
}
