using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing
{
    public class EventDbContext : DbContext
    {
        //public DbSet<EventLogEntry> Events { get; set; }
        public DbSet<FeedbackSubmittedEvent> feedbackSubmittedEvents { get; set; }


        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
