using System;
using System.Collections.Generic;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Repository.Abstract
{
    public interface IPatientRepository : ICRUD<Patient, long>, IGetEager<Patient, long>
    {
        public Patient GetUserByCredentials(String username, String password);
        Patient GetPatientByJMBG(string jmbg);
        List<Patient> GetBlockedPatients();
        List<Patient> GetPatientsForBlocking();
        Patient GetPatientToken(string token);
        Patient GetPatientByMail(string email);
        Patient GetPatientByUsername(string username);

    }
}
