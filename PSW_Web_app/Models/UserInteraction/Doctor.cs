using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSW_Web_app.Models.UserInteraction
{
    public class Doctor : User, IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Speciality Speciality { get; set; }
        [NotMapped]
        public virtual DoctorGrade DoctorGrade { get; set; }
        [NotMapped]
        public virtual List<BusinessDay> BussinesDays { get; set; }

        public Doctor()
        {
            UserType = UserType.Doctor;
        }

        public Doctor(long id, Speciality speciality, DoctorGrade doctorGrade, Person person, UserDetails userDetails, UserLogIn userLogIn)
        {
            Id = id;
            Speciality = speciality;
            DoctorGrade = doctorGrade;
            UserType = UserType.Doctor;
            Person = person;
            UserDetails = userDetails;
            UserLogIn = userLogIn;

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
