using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Doctor : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual DoctorGrade DoctorGrade { get; set; }

        public virtual User User { get; set; }

        public Doctor(long id, Speciality speciality, DoctorGrade doctorGrade, User user)
        {
            Id = id;
            Speciality = speciality;
            DoctorGrade = doctorGrade;
            User = user;
        }

        public Doctor() { }

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
