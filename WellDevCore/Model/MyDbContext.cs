using bolnica.Model.Dto;
using bolnica.Model.Users;
using Microsoft.EntityFrameworkCore;
using Model.Director;
using Model.Doctor;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model
{
    public class MyDbContext:DbContext
    {
        public DbSet<Operation> Operation { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Renovation> Renovation { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<DoctorGrade> DoctorGrade { get; set; }
        public DbSet<Hospitalization> Hospitalization { get; set; }
        public DbSet<Referral> Referral { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<BusinessDayDTO> BusinessDayDTO { get; set; }
        public DbSet<DoctorReportDTO> DoctorReportDTO { get; set; }
        public DbSet<ExaminationDTO> ExaminationDTO { get; set; }
        public DbSet<NotifyDoctorBusinessDay> NotifyDoctorBusinessDay { get; set; }
        public DbSet<PatientNotification> PatientNotification { get; set; }
        public DbSet<RoomOccupationReportDTO> RoomOccupationReportDTO { get; set; }
        public DbSet<SecretaryReportDTO> SecretaryReportDTO { get; set; }
        public DbSet<Allergy> Allergy { get; set; }
        public DbSet<Anemnesis> Anemnesis { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Drug> Drug { get; set; }
        public DbSet<Examination> Examination { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<PatientFile> PatientFile { get; set; }
        public DbSet<Period> Period { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Symptom> Symptom { get; set; }
        public DbSet<Therapy> Therapy { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<BusinessDay> BusinessDay { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Secretary> Secretary { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Town> Town { get; set; }
        public DbSet<User> User { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    }
}
