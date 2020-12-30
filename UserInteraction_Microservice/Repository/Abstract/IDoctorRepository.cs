using System;
using System.Collections.Generic;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Repository.Abstract
{
    public interface IDoctorRepository : ICRUD<Doctor, long>, IGetEager<Doctor, long>
    {
        public Doctor GetUserByCredentials(String username, String password);
        public IEnumerable<Doctor> GetDoctorsBySpeciality(Speciality speciality);
    }
}
