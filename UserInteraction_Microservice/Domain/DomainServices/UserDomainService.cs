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

        public UserDomainService(IDoctorAppService doctorAppService, IDirectorAppService directorAppService, ISecretaryAppService secretaryAppService, IPatientAppService patientAppService)
        {
            _doctorAppService = doctorAppService;
            _directorAppService = directorAppService;
            _secretaryAppService = secretaryAppService;
            _patientAppService = patientAppService;
        }

        public void Delete(User user)
        {
            if (user.UserType == UserType.Director)
                _directorAppService.Delete((Director)user);
            else if (user.UserType == UserType.Patient)
                _patientAppService.Delete((Patient)user);
            else if (user.UserType == UserType.Doctor)
                _doctorAppService.Delete((Doctor)user);
            else if (user.UserType == UserType.Secretary)
                _secretaryAppService.Delete((Secretary)user);
        }
    }
}
