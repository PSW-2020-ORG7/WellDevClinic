using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;
using WellDevCore.Model.dtos;

namespace WellDevCore.Model.Adapters
{
    public class DoctorAdapter
    {
        public static DoctorDTO DoctorToDoctorDTO(Doctor doctor)
        {
            DoctorDTO doctorDTO = new DoctorDTO();
            doctorDTO.Id = doctor.Id;
            doctorDTO.Name = doctor.FirstName;
            doctorDTO.Surname = doctor.LastName;
            doctorDTO.Speciality = doctor.Specialty.Name;
            List<BusinessDayDTO> businessDayDTOs = new List<BusinessDayDTO>();

            /*foreach (BusinessDay businessDay in doctor.BusinessDay)
            {
                BusinessDayDTO businessDayDTO = new BusinessDayDTO();
                businessDayDTO.Room = businessDay.room;
                businessDayDTO.Shift = businessDay.Shift;
                List<Period> list = new List<Period>();
                if(businessDay.ScheduledPeriods.Count > 0)
                {
                    foreach(Period p in businessDay.ScheduledPeriods)
                    {
                        list.Add(p);
                    }   
                }
                businessDayDTO.ScheduledPeriods = list;
                businessDayDTOs.Add(businessDayDTO);
            }*/

            //doctorDTO.BusinessDayDTO = businessDayDTOs;



            return doctorDTO;

        }
    }
}
