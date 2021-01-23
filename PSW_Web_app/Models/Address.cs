using System;

namespace PSW_Web_app.Models
{
    public class Address : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Street { get; set; }
        public int Number { get; set; }
        public String FullAddress { get; set; }
        public virtual Town Town { get; set; }
        public virtual State State { get; set; }

        public Address() {}

        public Address(long id, string street, int number, string fullAddress, Town town, State state)
        {
            Id = id;
            Street = street;
            Number = number;
            FullAddress = fullAddress;
            Town = town;
            State = state;
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