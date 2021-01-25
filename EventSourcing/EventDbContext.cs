
using EventSourcing.Events;
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
        public DbSet<NewExaminationTimeSpent> newExaminationTimeSpent { get; set; }
        public DbSet<RoomEvent> roomEvents { get; set; }
        public DbSet<MapEvent> mapEvent { get; set; }


        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
