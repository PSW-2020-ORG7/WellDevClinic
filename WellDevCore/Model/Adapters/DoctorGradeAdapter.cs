using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Doctor;
using PSW_Web_app.DTO;
/// <summary>
/// Maps DoctorGrade object to DoctorGradeDTO
/// </summary>
namespace PSW_Web_app.Adapters
{
    public class DoctorGradeAdapter
    {
       
        public static DoctorGradeDTO DoctorGradeToDoctorGradeDTO(DoctorGrade doctorGrade)
        {
            DoctorGradeDTO result = new DoctorGradeDTO();
            result.Id = doctorGrade.Id;
            result.Grades = doctorGrade.Grades;
            result.AverageGrades = doctorGrade.AverageGrade;
            result.Doctor = doctorGrade.Doctor;
            return result;
        }
    }
}
