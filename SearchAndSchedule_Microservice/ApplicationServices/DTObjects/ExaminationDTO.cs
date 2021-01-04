using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices.DTObjects
{
    public class ExaminationDTO
    {
        public  Doctor Doctor { get; set; }
        public  Patient Patient { get; set; }
        public  Room Room { get; set; }
        public  Period Period { get; set; }

        public ExaminationDTO() { }

        public ExaminationDTO(Period period)
        {
            Period = period;
        }


        public ExaminationDTO(Doctor doctor, Room room, Period period, Patient patient)
        {
            Doctor = doctor;
            Room = room;
            Period = period;
            Patient = patient;
        }


        public ExaminationDTO(Doctor doctor, Room room, Period period)
        {
            Doctor = doctor;
            Room = room;
            Period = period;
        }

        public ExaminationDTO(Doctor doctor, Period period)
        {
            Doctor = doctor;
            Period = period;
        }


        public ExaminationDTO(Patient patient, Period period)
        {
            Patient = patient;
            Period = period;
        }

        public ExaminationDTO(Room room, Period period)
        {
            Room = room;
            Period = period;
        }
    }
}
