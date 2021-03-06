﻿using System;
using System.Collections.Generic;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface IDoctorAppService : ICRUD<Doctor, long>, IGetEager<Doctor, long>
    {
        public Doctor LogIn(String username, String password);

        public IEnumerable<Doctor> GetDoctorsBySpeciality(Speciality speciality);
    }
}
