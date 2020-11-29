using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Model.Dto;
/// <summary>
/// Models DoctorGrade object for showing on frontend
/// </summary>
namespace PSW_Web_app.DTO
{
    public class DoctorGradeDTO
    {
        public List<GradeDTO> Grades { get; set; }
        public List<GradeDTO> AverageGrades { get; set; }
        public long Id { get; set; }
        public String Doctor { get; set; }

        public DoctorGradeDTO()
        {

        }
    }
}
