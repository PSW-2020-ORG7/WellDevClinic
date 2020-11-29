using bolnica.Model.Dto;
using Model.Doctor;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public  interface IDoctorGradeService : IService<DoctorGrade,long>
    {
        List<GradeDTO> GetAverageGrade(DoctorGrade survey);
        List<DoctorGrade> GetByDoctor(String doctor);
        List<GradeDTO> GetAverageGradeDoctor(List<DoctorGrade> surveys);
    }
}
