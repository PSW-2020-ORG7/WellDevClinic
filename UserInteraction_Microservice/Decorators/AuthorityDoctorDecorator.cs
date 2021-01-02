using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Decorators
{
    public class AuthorityDoctorDecorator : IDoctorAppService
    {
        private readonly IDoctorAppService _doctorAppService;
        private String Role { get; set; }

        private readonly Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityDoctorDecorator(IDoctorAppService doctorAppService)
        {
            this._doctorAppService = doctorAppService;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Delete"] = new List<string>() { "Director" },
                ["Edit"] = new List<string>() { "Director", "Doctor" },
                ["Get"] = new List<string>() { "Director", "Doctor", "Secretary" },
                ["GetAll"] = new List<string>() { "Director", "Doctor", "Secretary" },
                ["GetDoctorsBySpeciality"] = new List<string>() { "Doctor", "Patient" },
                ["Save"] = new List<string>() { "Director" },
                ["GetAllEager"] = new List<string>() { "Director" },
                ["GetEager"] = new List<string>() { "Director", "Secretary", "Doctor" }
            };

        }


        public void Delete(Doctor entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                _doctorAppService.Delete(entity);
        }

        public void Edit(Doctor entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                _doctorAppService.Edit(entity);
        }

        public Doctor Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _doctorAppService.Get(id);
            return null;
        }

        public IEnumerable<Doctor> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _doctorAppService.GetAll();
            return null;
        }

        public IEnumerable<Doctor> GetAllEager()
        {
            if (AuthorizedUsers["GetAllEager"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _doctorAppService.GetAllEager();
            return null;
        }

        public IEnumerable<Doctor> GetDoctorsBySpeciality(Speciality specialty)
        {
            if (AuthorizedUsers["GetDoctorsBySpeciality"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _doctorAppService.GetDoctorsBySpeciality(specialty);
            return null;
        }

        public Doctor GetEager(long id)
        {
            if (AuthorizedUsers["GetEager"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _doctorAppService.GetEager(id);
            return null;
        }

        public Doctor LogIn(string username, string password)
        {
            return _doctorAppService.LogIn(username, password);
        }

        public Doctor Save(Doctor entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _doctorAppService.Save(entity);
            return null;
        }
    }
}
