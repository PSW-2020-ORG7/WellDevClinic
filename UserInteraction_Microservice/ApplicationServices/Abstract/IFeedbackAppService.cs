﻿using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface IFeedbackAppService : ICRUD<Feedback, long>
    {
    }
}
