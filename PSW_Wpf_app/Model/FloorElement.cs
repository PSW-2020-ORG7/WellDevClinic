using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSW_Wpf_app.Model
{
    public class FloorElement
    {


        private string type;
        private int width;
        private int height;
        private int x;
        private int y;
        private string name;
        private int floor;
        private string info;
        private string buildingName;

        public string BuildingName
        {
            get { return buildingName; }
            set { buildingName = value; }
        }


        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }

        }

        public string Name
        {
            get { return name; }
            set { name = value; }

        }

        public int Floor
        {
            get { return floor; }
            set { floor = value; }

        }


        public FloorElement(string t, int w, int h, int xx, int yy)
        {
            type = t;
            width = w;
            height = h;
            x = xx;
            y = yy;

        }

        public FloorElement(string t, string n, int w, int h, int xx, int yy, int f, string i="")
        {
            type = t;
            name = n;
            width = w;
            height = h;
            x = xx;
            y = yy;
            floor = f;
            info = i;
        }

        public FloorElement(string t, string n, int w, int h, int xx, int yy, int f, string b, string i = "")
        {
            type = t;
            name = n;
            width = w;
            height = h;
            x = xx;
            y = yy;
            floor = f;
            buildingName = b;
            info = i;
        }

    }
}
