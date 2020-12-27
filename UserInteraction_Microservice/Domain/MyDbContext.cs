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
        public System.Data.Entity.DbSet<Doctor> Doctor { get; set; }
        public System.Data.Entity.DbSet<Director> Director { get; set; }
        public System.Data.Entity.DbSet<Patient> Patient { get; set; }
        public System.Data.Entity.DbSet<Secretary> Secretary { get; set; }
        public System.Data.Entity.DbSet<Address> Address { get; set; }
        public System.Data.Entity.DbSet<Article> Articles { get; set; }
        public System.Data.Entity.DbSet<DoctorGrade> DoctorGrade { get; set; }
        public System.Data.Entity.DbSet<Feedback> Feedback { get; set; }
        public System.Data.Entity.DbSet<Speciality> Speciality { get; set; }
        public System.Data.Entity.DbSet<State> State { get; set; }
        public System.Data.Entity.DbSet<Town> Town { get; set; }



        //public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().Map(dc => {
                dc.Properties(p => new { p.Id, p.FirstName, p.LastName, p.Jmbg });
                dc.ToTable("Person");
            
            }).Map(dc => {
                dc.Properties(p => new { p.Id, p.Username, p.Password, p.UserType });
                dc.ToTable("User");
            }).Map(dc => {
                dc.Properties(p => new { p.Id, p.DateOfBirth, p.Phone, p.MiddleName, p.Race, p.Gender, p.Email, p.Image, p.Address });
                dc.ToTable("UserDetails");
            
            }).Map(dc => {
                dc.Properties(p => new { p.Id, p.Speciality, p.DoctorGrade });
                dc.ToTable("Doctor");
            });

            modelBuilder.Entity<Patient>().Map(dc => {
                dc.Properties(p => new { p.Id, p.FirstName, p.LastName, p.Jmbg });
                dc.ToTable("Person");

            }).Map(dc => {
                dc.Properties(p => new { p.Id, p.Username, p.Password, p.UserType });
                dc.ToTable("User");
            }).Map(dc => {
                dc.Properties(p => new { p.Id, p.DateOfBirth, p.Phone, p.MiddleName, p.Race, p.Gender, p.Email, p.Image, p.Address });
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
                dc.Properties(p => new { p.Id, p.DateOfBirth, p.Phone, p.MiddleName, p.Race, p.Gender, p.Email, p.Image, p.Address });
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
                dc.Properties(p => new { p.Id, p.DateOfBirth, p.Phone, p.MiddleName, p.Race, p.Gender, p.Email, p.Image, p.Address });
                dc.ToTable("UserDetails");

            });
        }
    }
}
