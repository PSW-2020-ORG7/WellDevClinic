using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSW_Web_app.Models
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
