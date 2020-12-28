using System;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Address : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Street { get; set; }
        public int Number { get; set; }
        public String FullAddress { get; set; }
        public virtual Town Town { get; set; }

        public Address()
        {
        }

        public Address(long id, string street, int number, string fullAddress, Town town)
        {
            Id = id;
            Street = street;
            Number = number;
            FullAddress = fullAddress;
            Town = town;
        }

        public Address(long id, long townID, long stateID)
        {
            Id = id;
            Town = new Town(townID, stateID);
        }

        public void SetTown(Town newTown)
        {
            if (Town != newTown)
            {
                if (Town != null)
                {
                    Town oldTown = Town;
                    Town = null;
                    oldTown.RemoveAddress(this);
                }
                if (newTown != null)
                {
                    Town = newTown;
                    Town.AddAddress(this);
                }
            }
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