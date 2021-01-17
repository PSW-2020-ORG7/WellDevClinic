using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSW_Web_app.Models
{
    [NotMapped]
    public class DoctorGradeQuestion
    {
        public long Id { get; set; }
        public double Grade { get; set; }
        public string Question { get; set; }
        public DoctorGradeQuestion() { }
        public DoctorGradeQuestion(double grade, string question)
        {
            Grade = grade;
            Question = question;
        }

    }
}
