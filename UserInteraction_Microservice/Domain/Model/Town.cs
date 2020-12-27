using System;
using System.Collections.Generic;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Town : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String PostalNumber { get; set; }
        public virtual State State { get; set; }
        private List<Address> address;

        public Town(long id, string name, string postalNumber, State state)
        {
            Id = id;
            Name = name;
            PostalNumber = postalNumber;
            State = state;
            address = new List<Address>();
        }

        public Town(long id, long stateID)
        {
            Id = id;
            State = new State(stateID);
        }

        public List<Address> GetAddress()
        {
            if (address == null)
                address = new List<Address>();
            return address;
        }

        public void AddAddress(Address newAddress)
        {
            if (newAddress == null)
                return;
            if (this.address == null)
                this.address = new List<Address>();
            if (!this.address.Contains(newAddress))
            {
                this.address.Add(newAddress);
                newAddress.SetTown(this);
            }
        }

        public void RemoveAddress(Address oldAddress)
        {
            if (oldAddress == null)
                return;
            if (this.address != null)
                if (this.address.Contains(oldAddress))
                {
                    this.address.Remove(oldAddress);
                    oldAddress.SetTown((Town)null);
                }
        }

        public State GetState()
        {
            return State;
        }


        public void SetState(State newState)
        {
            if (State != newState)
            {
                if (State != null)
                {
                    State oldState = State;
                    State = null;
                    oldState.RemoveTown(this);
                }
                if (newState != null)
                {
                    State = newState;
                    State.AddTown(this);
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