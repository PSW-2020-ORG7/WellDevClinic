using Microsoft.EntityFrameworkCore;
using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.Domain
{
    public class MyDbContext : DbContext
    {
        public DbSet<Room> Room { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Renovation> Renovation { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<EquipmentStatistic> EquipmentStatistic { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Renovation>().OwnsOne(r => r.Period);
        }
    }
}
