using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
  
    public class DoctorGrade : IIdentifiable<long>
    {
        public long Id { get; set; }
        public int NumberOfGrades { get; set; }
        public virtual List<DoctorGradeQuestion> DoctorGradeQuestions { get; set; }
        public virtual List<DoctorGradeQuestion> AverageGrade { get; set; }
        public virtual Doctor Doctor { get; set; }
        

        public DoctorGrade() {}

        public DoctorGrade(long id, int numberOfGrades, Doctor doctor)
        {
            Id = id;
            NumberOfGrades = numberOfGrades;
            DoctorGradeQuestions = new List<DoctorGradeQuestion>();
            AverageGrade = new List<DoctorGradeQuestion>();
            Doctor = doctor;
        }

        public DoctorGrade(List<DoctorGradeQuestion> grades, Doctor doctor)
        {
            DoctorGradeQuestions = grades;
            Doctor = doctor;
        }

        public DoctorGrade(long id)
        {
            Id = id;
        }
        public long GetId()
        {
            return this.Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}
