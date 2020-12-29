using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Repository.Abstract
{
    public interface IPatientRepository : ICRUD<Patient, long>
    {
        public Patient GetUserByCredentials(String username, String password);
    }
}
