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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
