using System;
using System.Collections.Generic;

namespace UserInteraction_Microservice.Domain.Model
{
    public class State : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public virtual List<Town> Town { get; set; }

        public State() {}

        public State(long id, String name, String code)
        {
            Id = id;
            Name = name;
            Code = code;
            Town = new List<Town>();
        }

        public State(long id)
        {
            Id = id;
        }

        public List<Town> GetTown()
        {
            if (Town == null)
                Town = new List<Town>();
            return Town;
        }

        public void AddTown(Town newTown)
        {
            if (newTown == null)
                return;
            if (this.Town == null)
                this.Town = new List<Town>();
            if (!this.Town.Contains(newTown))
            {
                this.Town.Add(newTown);
                newTown.SetState(this);
            }
        }

        public void RemoveTown(Town oldTown)
        {
            if (oldTown == null)
                return;
            if (this.Town != null)
                if (this.Town.Contains(oldTown))
                {
                    this.Town.Remove(oldTown);
                    oldTown.SetState((State)null);
                }
        }

        public void RemoveAllTown()
        {
            if (Town != null)
            {
                List<Town> tmpTown = new List<Town>();
                foreach (Town oldTown in Town)
                    tmpTown.Add(oldTown);
                Town.Clear();
                foreach (Town oldTown in tmpTown)
                    oldTown.SetState((State)null);
                tmpTown.Clear();
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