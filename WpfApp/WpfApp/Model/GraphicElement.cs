using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
   public class GraphicElement
    {
        private string type;
        private int width;
        private int height;
        private int x;
        private int y;
        private string name;


        public string Type
        {
            get { return type; }
            set { }
        }

        public int Width
        {
            get { return width; }
            set { }
        }

        public int Height
        {
            get { return height; }
            set { }
        }
    
        public int X
        {
            get { return x; }
            set { }
        }
        
        public int Y
        {
            get { return y; }
            set { }

        }

        public string Name
        {
            get { return name; }
            set { }

        }

        public GraphicElement(string t, int w, int h, int xx, int yy)
        {
            type = t;
            width = w;
            height = h;
            x = xx;
            y = yy;

        }

        public GraphicElement(string t, int w, int h, int xx, int yy, string n="")
        {
            type = t;
            width = w;
            height = h;
            x = xx;
            y = yy;
            name = n;

        }
    }
}
