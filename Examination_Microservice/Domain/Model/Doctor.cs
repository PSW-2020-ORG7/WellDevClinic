using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Examination_Microservice.Domain.Model
{
    public class Doctor : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual Person Person { get; set; }
        public virtual DoctorGrade DoctorGrade { get; set; }

        public Doctor() { }
        public Doctor(long id, Speciality speciality, Person person, DoctorGrade doctorGrade)
        {
            Id = id;
            Speciality = speciality;
            Person = person;
            DoctorGrade = doctorGrade;
        }

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
