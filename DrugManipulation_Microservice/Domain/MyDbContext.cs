using DrugManipulation_Microservice.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrugManipulation_Microservice.Domain
{
    public class MyDbContext : DbContext
    {
        public DbSet<Drug> Drug { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    }
}
