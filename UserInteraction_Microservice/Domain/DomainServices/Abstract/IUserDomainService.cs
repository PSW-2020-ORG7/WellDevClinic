﻿using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Domain.DomainServices
{
    public interface IUserDomainService
    {
        public User LogIn(String username, String password);
        public User Registration(User user);
    }
}
