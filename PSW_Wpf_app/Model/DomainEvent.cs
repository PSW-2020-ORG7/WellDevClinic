using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public abstract class DomainEvent
    {
        public DomainEvent()
        {
            Id = Guid.NewGuid();
            TimeStamp = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
