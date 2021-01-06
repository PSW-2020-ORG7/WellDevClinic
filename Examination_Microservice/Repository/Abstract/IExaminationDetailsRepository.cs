﻿using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.Repository.Abstract
{
    public interface IExaminationDetailsRepository : ICRUD<ExaminationDetails,long>, IGetEager<ExaminationDetails,long>
    {
        public IEnumerable<ExaminationDetails> GetExaminationDetailsByDoctor(Doctor doctor);
        public IEnumerable<ExaminationDetails> GetExaminationDetailsByPatient(Patient patient);

    }
}
