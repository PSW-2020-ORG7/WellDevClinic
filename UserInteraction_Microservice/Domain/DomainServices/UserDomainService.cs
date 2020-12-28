﻿using System;
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

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<long> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Save(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
