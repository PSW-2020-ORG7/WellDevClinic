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

        public UserDomainService(IDirectorAppService directorAppService)
        {
            _directorAppService = directorAppService;
        }



        /*   public UserDomainService(IDoctorAppService doctorAppService, IDirectorAppService directorAppService, ISecretaryAppService secretaryAppService, IPatientAppService patientAppService)
           {
               _doctorAppService = doctorAppService;
               _directorAppService = directorAppService;
               _secretaryAppService = secretaryAppService;
               _patientAppService = patientAppService;
           }

   */


        public void Delete(User user)
        {
         /*   if (user.UserType == UserType.Director)
                _directorAppService.Delete((Director)user);
            else if (user.UserType == UserType.Patient)
                _patientAppService.Delete((Patient)user);
            else if (user.UserType == UserType.Doctor)
                _doctorAppService.Delete((Doctor)user);
            else if (user.UserType == UserType.Secretary)
                _secretaryAppService.Delete((Secretary)user);*/
        }

        public void Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Save(User user)
        {
            if (user.UserType == UserType.Director)
                return _directorAppService.Save((Director)user);
            else if (user.UserType == UserType.Patient)
               return _patientAppService.Save((Patient)user);
            else if (user.UserType == UserType.Doctor)
              return  _doctorAppService.Save((Doctor)user);
            else if (user.UserType == UserType.Secretary)
              return  _secretaryAppService.Save((Secretary)user);

            return null;
        }

    }
}
