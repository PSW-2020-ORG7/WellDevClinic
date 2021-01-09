using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Domain
{
    public class MyDbContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<UserLogIn> UserLogIn { get; set; }
        public DbSet<DoctorGrade> DoctorGrade { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Secretary> Secretary { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Feedback> Feedback { get; set; }



        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*  modelBuilder.Entity<Doctor>().Property(p => p.User.Id).HasColumnName("UserId");
              modelBuilder.Entity<Patient>().Property(p => p.User.Id).HasColumnName("UserId");
              modelBuilder.Entity<Director>().Property(p => p.User.Id).HasColumnName("UserId");
              modelBuilder.Entity<Secretary>().Property(p => p.User.Id).HasColumnName("UserId");*/
            modelBuilder.Entity<Address>().OwnsOne(b => b.Town);
            modelBuilder.Entity<Address>().OwnsOne(b => b.State);
            modelBuilder.Entity<UserLogIn>(entity => {
                entity.HasIndex(e => e.Username).IsUnique();
            });

        }
    }
}
