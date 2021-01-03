using Microsoft.EntityFrameworkCore;
using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain
{
    public class MyDbContext : DbContext
    {

        public DbSet<BussinesDay> BussinesDay { get; set; }
        public DbSet<Examination> Examination { get; set; }



        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
