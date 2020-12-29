using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface IDoctorAppService : ICRUD<Doctor, long>
    {
        public Doctor LogIn(String username, String password);
    }
}
