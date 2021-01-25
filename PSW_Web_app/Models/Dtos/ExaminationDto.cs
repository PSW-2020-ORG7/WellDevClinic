using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Web_app.Models.Dtos
{
    public class ExaminationDto
    {
        public String Specialist { get; set; }
        public String TextReferral { get; set; }
        public String Doctor { get; set; }
        public List<String> Drug { get; set; }
        public String Date { get; set; }

        public ExaminationDto() { }
    }
}
