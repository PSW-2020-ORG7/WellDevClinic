using Microsoft.EntityFrameworkCore;
using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter
{
    public class MyDbContext : DbContext
    {
        public DbSet<Api> ApiKeys { get; set; }
        public DbSet<ActionAndBenefit> ActionsAndBenefits { get; set; }
        public DbSet<TenderOffer> TenderOffers { get; set; }
        public DbSet<Tender> Tender { get; set; }
        public DbSet<PharmacyEmails> Email { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tender>().OwnsOne(t => t.Period);
            modelBuilder.Entity<PharmacyEmails>().OwnsOne(t => t.Mail);
            modelBuilder.Entity<TenderOffer>().OwnsOne(t => t.Mail);
        }
    }
}
