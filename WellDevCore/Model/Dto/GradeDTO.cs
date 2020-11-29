using System;
using System.Collections.Generic;
using System.Text;

namespace bolnica.Model.Dto
{
    public class GradeDTO
    {
        public long Id { get; set; }
        public int Grade { get; set; }
        public string Question { get; set; }

        public GradeDTO()
        {

        }

        public GradeDTO(int grade, string question)
        {
            Grade = grade;
            Question = question;
        }
    }
}
