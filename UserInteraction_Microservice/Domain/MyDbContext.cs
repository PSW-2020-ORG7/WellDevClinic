using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Domain
{
    public class MyDbContext : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<Address> Address { get; set; }
        public System.Data.Entity.DbSet<Speciality> Speciality { get; set; }
        public System.Data.Entity.DbSet<State> State { get; set; }
        public System.Data.Entity.DbSet<Town> Town { get; set; }
        public System.Data.Entity.DbSet<DoctorGrade> DoctorGrade { get; set; }
        public System.Data.Entity.DbSet<Patient> Patient { get; set; }
        public System.Data.Entity.DbSet<Doctor> Doctor { get; set; }
        public System.Data.Entity.DbSet<Director> Director { get; set; }
        
        public System.Data.Entity.DbSet<Secretary> Secretary { get; set; }
     
        public System.Data.Entity.DbSet<Article> Articles { get; set; }

        public System.Data.Entity.DbSet<Feedback> Feedback { get; set; }
    


        public MyDbContext(String options) : base(options) {
            Database.SetInitializer<MyDbContext>(new CreateDatabaseIfNotExists<MyDbContext>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Speciality>().ToTable("Speciality");
            modelBuilder.Entity<State>().ToTable("State");
            modelBuilder.Entity<Town>().ToTable("Town");
            modelBuilder.Entity<DoctorGrade>().ToTable("DoctorGrade");
            modelBuilder.Entity<Article>().ToTable("Article");
            modelBuilder.Entity<Feedback>().ToTable("Feedback");

            modelBuilder.Entity<Patient>().Map(dc => {
                dc.Properties(p => new { p.Id, p.FirstName, p.LastName, p.Jmbg });
                dc.ToTable("Person");

            }).Map(dc => {
                dc.Properties(p => new { p.Id, p.Username, p.Password, p.UserType });
                dc.ToTable("User");
            }).Map(dc => {
                dc.Properties(p => new { p.Id, p.DateOfBirth, p.Phone, p.MiddleName, p.Race, p.Gender, p.Email, p.Image, AddressId = p.Address.GetId()});
                dc.ToTable("UserDetails");

            }).Map(dc => {
                dc.Properties(p => new { p.Id, p.Guest, p.Blocked });
                dc.ToTable("Patient");
            });

            modelBuilder.Entity<Director>().Map(dc => {
                dc.Properties(p => new { p.Id, p.FirstName, p.LastName, p.Jmbg });
                dc.ToTable("Person");

            }).Map(dc => {
                dc.Properties(p => new { p.Id, p.Username, p.Password, p.UserType });
                dc.ToTable("User");
            }).Map(dc => {
                dc.Properties(p => new { p.Id, p.DateOfBirth, p.Phone, p.MiddleName, p.Race, p.Gender, p.Email, p.Image, AddressId = p.Address.GetId() });
                dc.ToTable("UserDetails");

            });

            modelBuilder.Entity<Secretary>().Map(dc =>
            {
                dc.Properties(p => new { p.Id, p.FirstName, p.LastName, p.Jmbg });
                dc.ToTable("Person");

            }).Map(dc =>
            {
                dc.Properties(p => new { p.Id, p.Username, p.Password, p.UserType });
                dc.ToTable("User");
            }).Map(dc =>
            {
                dc.Properties(p => new { p.Id, p.DateOfBirth, p.Phone, p.MiddleName, p.Race, p.Gender, p.Email, p.Image, AddressId = p.Address.GetId() });
                dc.ToTable("UserDetails");

            });


            modelBuilder.Entity<Doctor>().Map(dc => {
                dc.Properties(p => new { p.Id, p.FirstName, p.LastName, p.Jmbg });
                dc.ToTable("Person");

            }).Map(dc => {
                dc.Properties(p => new { p.Id, p.Username, p.Password, p.UserType });
                dc.ToTable("User");

            }).Map(dc => {
                dc.Properties(p => new { p.Id, p.DateOfBirth, p.Phone, p.MiddleName, p.Race, p.Gender, p.Email, p.Image, AddressId = p.Address.GetId() });
                dc.ToTable("UserDetails");

            }).Map(dc => {
                dc.Properties(p => new { p.Id, SpecialityId = p.Speciality.Id, DoctorGradeId = p.DoctorGrade.Id });
                dc.ToTable("Doctor");
            });
        }
    }
}
