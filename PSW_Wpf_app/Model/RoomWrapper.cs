using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public class RoomWrapper
    {
        private FloorElement floorElement;
        private string building;

        public FloorElement FloorElement
        {
            get { return floorElement; }
            set { floorElement = value; }
        }

        public string Building
        {
            get { return building; }
            set { building = value; }
        }

        public RoomWrapper(FloorElement f, string b)
        {
            FloorElement = f;
            Building = b;
        }

    }
}
