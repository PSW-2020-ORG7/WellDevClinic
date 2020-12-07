using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Model
{
    public class MyDbContext : DbContext
    {
        public DbSet<Api> ApiKeys { get; set; }
        public DbSet<ActionAndBenefit> ActionsAndBenefits { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // Test data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Api>().HasData(
                new Api("PH1", "4545-as84-8s8g-zXCV", "localhost:4200/Ph1"),
                new Api("PH2", "7788-AV5R-zxQt-5845", "localhost:4200/Ph2"),
                new Api("PH3", "9745-At7S-Aqtr-5q8t", "localhost:4200/Ph3"),
                new Api("PH4", "HgT8-n47E-bE41-2gt5", "localhost:4200/Ph4")
                );

            modelBuilder.Entity<ActionAndBenefit>().HasData(
                new ActionAndBenefit(1, "PH1", "Andol on sale! 50% off!!", 10, 15),
                new ActionAndBenefit(2, "PH1", "Cheap bromazepam on huge quantities!!", 1, 30),
                new ActionAndBenefit(3, "PH3", "Aspirin C for free!!", 8, 13),
                new ActionAndBenefit(4, "PH3", "Amazing deal!! Brufen was 5$, now 15$", 10, 45),
                new ActionAndBenefit(5, "PH2", "Cant miss!! Vitamin C just for 99$", 18, 50),
                new ActionAndBenefit(6, "PH1", "Cheap sedatives!", 10, 15)
               );
        }
    }
}
