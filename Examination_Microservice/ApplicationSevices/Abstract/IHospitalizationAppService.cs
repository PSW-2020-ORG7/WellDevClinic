﻿using Examination_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.ApplicationSevices.Abstract
{
    public interface IHospitalizationAppService : ICRUD<Hospitalization,long>
    {
        public IEnumerable<Hospitalization> GetHospitalizationByDoctor(Doctor doctor);
    }
}
