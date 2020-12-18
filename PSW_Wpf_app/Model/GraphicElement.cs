using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSW_Wpf_app.Model
{
   public class GraphicElement
    {
        private string type;
        private int width;
        private int height;
        private int x;
        private int y;
        private string name;
        private string info;

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

        public GraphicElement(string t, int w, int h, int xx, int yy)
        {
            type = t;
            width = w;
            height = h;
            x = xx;
            y = yy;

        }

        public GraphicElement(string t, int w, int h, int xx, int yy, string n="", string i = "")
        {
            type = t;
            width = w;
            height = h;
            x = xx;
            y = yy;
            name = n;
            info = i;
        }
    }
}
