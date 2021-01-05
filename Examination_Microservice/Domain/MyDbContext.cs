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

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
