using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Model.Dto
{
    public class RoomOccupationReportDTO
    {
        public virtual Room room { get; set; }
        public long Id { get; set; }
        public virtual List<Renovation> renovations { get; set; }

        public virtual List<Operation> operations { get; set; }

        public virtual List<Examination> examinations { get; set; }
        public virtual List<Examination> previousExaminations { get; set; }

        public virtual List<Hospitalization> hospitalizations { get; set; }

        public virtual Period period { get; set; }

        public RoomOccupationReportDTO()
        {

        }

        public RoomOccupationReportDTO(Room room, List<Renovation> renovations, List<Operation> operations, List<Examination> examinations, List<Hospitalization> hospitalizations, Period period, List<Examination> previousExam)
        {
            this.room = room;
            this.renovations = renovations;
            this.operations = operations;
            this.examinations = examinations;
            this.hospitalizations = hospitalizations;
            this.period = period;
            this.previousExaminations = previousExam;
        }
    }
}
