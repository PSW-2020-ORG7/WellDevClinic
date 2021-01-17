using Examination_Microservice.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;



namespace Examination_Microservice.Domain
{
    public class MyDbContext : DbContext
    {
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<ExaminationDetails> ExaminationDetails { get; set; }
        public DbSet<Sympthom> Sympthom { get; set; }
        public DbSet<Therapy> Therapy { get; set; }
        public DbSet<Referral> Referral { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PatientFile> PatientFile { get; set; }
        public DbSet<Hospitalization> Hospitalization { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExaminationDetails>().OwnsOne(e => e.Period);
            modelBuilder.Entity<Prescription>().OwnsOne(p => p.Period);
            modelBuilder.Entity<Referral>().OwnsOne(r => r.Period);
            modelBuilder.Entity<Therapy>().OwnsOne(t => t.Period);
            modelBuilder.Entity<Hospitalization>().OwnsOne(h => h.Period);
        }
    }
}
