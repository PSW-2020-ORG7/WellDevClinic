using Repository;
using System;
using Model.Users;
using bolnica.Service;
using System.Collections.Generic;
using Model.Doctor;

namespace Model.PatientSecretary
{
   public class Examination : IIdentifiable<long>
   {
        public long Id { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Model.Users.Doctor Doctor { get; set; }
        public virtual Period Period { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
        public virtual Prescription Prescription { get; set; }
        public virtual Anemnesis Anemnesis { get; set; }
        public virtual Therapy Therapy { get; set; }
        public virtual Referral Refferal { get; set; }
        public Boolean Canceled { get; set; }
        public DateTime CanceledDate { get; set; }

        public Examination(long id, Patient user, Users.Doctor doctor, Period period, Diagnosis diagnosis) : this(id)
        {
            Patient = user;
            Doctor = doctor;
            Period = period;
            Diagnosis = diagnosis;
        }

        public Examination(long id,  Users.Doctor doctor, Period period)
        {
            Id = id;
            Doctor = doctor;
            Period = period;
        }

        public Examination( Users.Doctor doctor)
        {
            Doctor = doctor;
        }

        public Examination(Patient patient, Users.Doctor doctor, Period period)
        {
            Patient = patient;
            Doctor = doctor;
            Period = period;
        }

        public Examination(long id, Patient patient, Users.Doctor doctor, Period period)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            Period = period;
           ;
        }

        public Examination(long id, Patient user,Users.Doctor doctor, Period period, Diagnosis diagnosis, Anemnesis anemnesis, Therapy therapy, Referral refferal, Prescription prescription)
        {
            Id = id;
            Patient = user;
            Doctor = doctor;
            Period = period;
            Diagnosis = diagnosis;
            Prescription = prescription;
            Anemnesis = anemnesis;
            Therapy = therapy;
            Refferal = refferal;
        } 
        
        public Examination(Patient user, Users.Doctor doctor, Period period, Diagnosis diagnosis, Anemnesis anemnesis, Therapy therapy, Referral refferal, Prescription prescription)
        {
            Patient = user;
            Doctor = doctor;
            Period = period;
            Diagnosis = diagnosis;
            Prescription = prescription;
            Anemnesis = anemnesis;
            Therapy = therapy;
            Refferal = refferal;
        }

        public Examination(long id)
        {
            Id = id;
        }

        public Examination(long id, Patient patient, bool canceled, DateTime date)
        {
            Id = id;
            Patient = patient;
            Canceled = canceled;
            CanceledDate = date;
        }

        public Examination() { }

        public long GetId()
        {
            return this.Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }

    }
}