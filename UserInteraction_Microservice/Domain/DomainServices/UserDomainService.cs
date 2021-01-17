using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Domain.DomainServices
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IDoctorAppService _doctorAppService;
        private readonly IDirectorAppService _directorAppService;
        private readonly ISecretaryAppService _secretaryAppService;
        private readonly IPatientAppService _patientAppService;

        public UserDomainService(IDirectorAppService directorAppService, IDoctorAppService doctorAppService, ISecretaryAppService secretaryAppService, IPatientAppService patientAppService)
        {
            _directorAppService = directorAppService;
            _doctorAppService = doctorAppService;
            _secretaryAppService = secretaryAppService;
            _patientAppService = patientAppService;
        }

        public User LogIn(string username, string password)
        {
            User user;
            if ((user = _doctorAppService.LogIn(username, password)) != null)
                return user;
            if ((user = _directorAppService.LogIn(username, password)) != null)
                return user;
            if ((user = _secretaryAppService.LogIn(username, password)) != null)
                return user;
            if ((user = _patientAppService.LogIn(username, password)) != null)
                return user;

            return user;

        }

        public User Registration(User user)
        {
            if (user.UserType == UserType.Director)
                return _directorAppService.Save((Director)user);
            if (user.UserType == UserType.Doctor)
                return _doctorAppService.Save((Doctor)user);
            if (user.UserType == UserType.Patient) { 
                _patientAppService.Save((Patient)user);
                return null;
            }
            if (user.UserType == UserType.Secretary)
                return _secretaryAppService.Save((Secretary)user);
            
            return null;
        }
    }
}
