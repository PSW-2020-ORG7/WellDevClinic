using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchAndSchedule_Microservice.Decorators
{
    public class AuthorityExaminationDecorator : IExaminationAppService
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
                ["GetUpcomingExaminationsByDoctor"] = new List<string>() { "Patient", "Secretary", "Doctor" },
                ["GetUpcomingExaminationsByPatient"] = new List<string>() { "Patient", "Secretary", "Doctor" },
                ["GetExaminationRoom"] = new List<string>() { "Patient", "Secretary", "Doctor" },
                ["GetUpcomingExaminationsByRoomAndPeriod"] = new List<string>() { "Patient", "Secretary", "Doctor" }
             };

        }
        public void Delete(UpcomingExamination entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                _examinationAppService.Delete(entity);
        }

        public void Edit(UpcomingExamination entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                _examinationAppService.Edit(entity);
        }

        public UpcomingExamination Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return _examinationAppService.Get(id);
            return null;
        }

        public IEnumerable<UpcomingExamination> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return _examinationAppService.GetAll();
            return null;
        }

        public UpcomingExamination Save(UpcomingExamination entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return _examinationAppService.Save(entity);
            return null;
        }

        public List<UpcomingExamination> GetUpcomingExaminationsByDoctor(Doctor doctor)
        {
            if (AuthorizedUsers["GetUpcomingExaminationsByDoctor"].SingleOrDefault(x => x == Role) != null)
                return _examinationAppService.GetUpcomingExaminationsByDoctor(doctor);
            return null;
        }

        public List<UpcomingExamination> GetUpcomingExaminationsByPatient(Patient patient)
        {
            if (AuthorizedUsers["GetUpcomingExaminationsByPatient"].SingleOrDefault(x => x == Role) != null)
                return _examinationAppService.GetUpcomingExaminationsByPatient(patient);
            return null;
        }

        public Room GetExaminationRoom(UpcomingExamination examination)
        {
            if (AuthorizedUsers["GetExaminationRoom"].SingleOrDefault(x => x == Role) != null)
                return _examinationAppService.GetExaminationRoom(examination);
            return null;
        }

        public List<UpcomingExamination> GetUpcomingExaminationsByRoomAndPeriod(Room room, Period period)
        {
            if (AuthorizedUsers["GetExGetUpcomingExaminationsByRoomAndPeriodaminationRoom"].SingleOrDefault(x => x == Role) != null)
                return _examinationAppService.GetUpcomingExaminationsByRoomAndPeriod(room, period);
            return null;
        }

        public List<Patient> GetPatientsForBlocking()
        {
            throw new NotImplementedException();
        }
    }
}
