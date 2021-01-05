using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain.Model
{
    public class DoctorGrade : IIdentifiable<long>
    {
        public long Id { get; set; }
        public int NumberOfGrades { get; set; }
        public virtual List<DoctorGradeQuestion> DoctorGradeQuestions { get; set; }
        public virtual List<DoctorGradeQuestion> AverageGrade { get; set; }

        public DoctorGrade() { }

        public DoctorGrade(long id, int numberOfGrades)
        {
            Id = id;
            NumberOfGrades = numberOfGrades;
            DoctorGradeQuestions = new List<DoctorGradeQuestion>();
            AverageGrade = new List<DoctorGradeQuestion>();
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
