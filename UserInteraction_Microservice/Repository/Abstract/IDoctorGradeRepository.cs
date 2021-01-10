using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Repository.Abstract
{
    public interface IDoctorGradeRepository :ICRUD<DoctorGrade,long>
    {
        List<DoctorGrade> GetByDoctor(string doctor);
    }
}
