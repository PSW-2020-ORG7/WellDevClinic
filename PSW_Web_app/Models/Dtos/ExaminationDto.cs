using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Web_app.Models.Dtos
{
    public class ExaminationDto
    {
        public String specialist { get; set; }
        public String textReferral { get; set; }
        public String doctor { get; set; }
        public List<String> drug { get; set; }
        public String date { get; set; }

        public ExaminationDto() { }
    }
}
