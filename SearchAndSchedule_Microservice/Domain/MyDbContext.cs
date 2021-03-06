﻿using Microsoft.EntityFrameworkCore;
using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain
{
    public class MyDbContext : DbContext
    {

        public DbSet<BusinessDay> BussinesDay { get; set; }
        public DbSet<UpcomingExamination> Examination { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }



        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessDay>().OwnsOne(b => b.Shift);
            modelBuilder.Entity<UpcomingExamination>().OwnsOne(e => e.Period);
            modelBuilder.Entity<Operation>().OwnsOne(e => e.Period);
            modelBuilder.Entity<BusinessDay>().OwnsMany(b => b.ScheduledPeriods);
            modelBuilder.Entity<Address>().OwnsOne(b => b.Town);
              modelBuilder.Entity<Address>().OwnsOne(b => b.State);
            /*modelBuilder.Entity<Address>().Ignore(b => b.Town);
            modelBuilder.Entity<Address>().Ignore(b => b.State);
            modelBuilder.Entity<State>().HasNoKey();
            modelBuilder.Entity<Town>().HasNoKey();*/

        }

    }
}
