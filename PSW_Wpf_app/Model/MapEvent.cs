using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public class MapEvent:DomainEvent
    {
        public string BuildingName { get; private set; }

        public int FloorLevel { get; private set; }
        public string Username { get; private set; }

        public MapEvent(string buildingName, int floorLevel, string username) : base()
        {
            this.BuildingName = buildingName;
            this.FloorLevel = floorLevel;
            this.Username = username;
        }
    }
}
