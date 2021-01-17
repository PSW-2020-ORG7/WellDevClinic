using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain.Model
{
    public class Doctor : User,  IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Speciality Speciality { get; set; }
        [NotMapped]
        public virtual DoctorGrade DoctorGrade { get; set; }
        [NotMapped]
        public virtual List<BusinessDay> BussinesDays { get; set; }

        public Doctor(long id, Speciality speciality, Person person, DoctorGrade doctorGrade, List<BusinessDay> bussinesDays)
        {
            Id = id;
            Speciality = speciality;
            Person = person;
            DoctorGrade = doctorGrade;
            BussinesDays = bussinesDays;
        }

        public Doctor(){ }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
