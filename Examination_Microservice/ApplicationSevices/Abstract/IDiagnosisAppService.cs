﻿using Examination_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.ApplicationSevices.Abstract
{
    public interface IDiagnosisAppService : ICRUD<Diagnosis, long>
    {
    }
}
