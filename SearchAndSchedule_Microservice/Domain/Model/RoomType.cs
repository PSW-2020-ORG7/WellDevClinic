using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain.Model
{
    public class RoomType : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public RoomType() { }
        public RoomType(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
