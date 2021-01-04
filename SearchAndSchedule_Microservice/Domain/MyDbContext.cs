using Microsoft.EntityFrameworkCore;
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



        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessDay>().OwnsOne(b => b.Shift);
            modelBuilder.Entity<UpcomingExamination>().OwnsOne(e => e.Period);
            modelBuilder.Entity<BusinessDay>().OwnsMany(b => b.ScheduledPeriods);
        }

    }
}
