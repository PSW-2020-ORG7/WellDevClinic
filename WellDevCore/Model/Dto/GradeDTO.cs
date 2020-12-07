using System;
using System.Collections.Generic;
using System.Text;

namespace bolnica.Model.Dto
{
    public class GradeDTO
    {
        public long Id { get; set; }
        public double Grade { get; set; }
        public string Question { get; set; }

        public GradeDTO()
        {

        }

        public GradeDTO(double grade, string question)
        {
            Grade = grade;
            Question = question;
        }
    }
}
