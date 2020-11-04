using Castle.Components.DictionaryAdapter;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Model.Doctor
{
   public class DoctorGrade : IIdentifiable<long>
    {
        [NotMapped] public Dictionary<String, double> GradesForEachQuestions { get; set; }
        public int NumberOfGrades { get; set; }

        public long Id { get; set; }

        public double AverageGrade
        {
            get
            {
                return GradesForEachQuestions.Values.Sum()/ GradesForEachQuestions.Keys.Count;
            }
            set
            {

            }
        }


        public DoctorGrade() { }
        public DoctorGrade(long id, int numberOfGrades)
        {
            NumberOfGrades = numberOfGrades;
            Id = id;
        }

        public DoctorGrade( long id, int numberOfGrades, Dictionary<string, double> gradesForEachQuestions)
        {
            GradesForEachQuestions = gradesForEachQuestions;
            NumberOfGrades = numberOfGrades;
            Id = id;
        }

        public DoctorGrade(int numberOfGrades, Dictionary<string, double> gradesForEachQuestions)
        {
            NumberOfGrades = numberOfGrades;
            GradesForEachQuestions = gradesForEachQuestions;
        }

        public DoctorGrade(long id)
        {
            this.Id = id;
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