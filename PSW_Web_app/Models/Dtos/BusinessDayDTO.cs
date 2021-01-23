using PSW_Web_app.Models.SearchAndSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Web_app.Models.Dtos
{
    public class BusinessDayDTO
    {
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Room Room { get; set; }
        public Period Period { get; set; }

        public BusinessDayDTO() { }

        public BusinessDayDTO(Period period)
        {
            Period = period;
        }


        public BusinessDayDTO(Doctor doctor, Room room, Period period, Patient patient)
        {
            Doctor = doctor;
            Room = room;
            Period = period;
            Patient = patient;
        }


        public BusinessDayDTO(Doctor doctor, Room room, Period period)
        {
            Doctor = doctor;
            Room = room;
            Period = period;
        }

        public BusinessDayDTO(Doctor doctor, Period period)
        {
            Doctor = doctor;
            Period = period;
        }


        public BusinessDayDTO(Patient patient, Period period)
        {
            Patient = patient;
            Period = period;
        }

        public BusinessDayDTO(Room room, Period period)
        {
            Room = room;
            Period = period;
        }
    }
}
