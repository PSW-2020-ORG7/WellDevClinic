using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class ShapeViewModel
    {
        public static List<GraphicElement> Read()
        {
            List<GraphicElement> shapes = new List<GraphicElement>();

            //string path = @"C:\Users\Lenovo\Downloads\WpfAppNOVO\WpfApp\primer.txt";

            string path = @"C:\Users\Maja\Desktop\psw\WellDevClinic\WpfApp\primer.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Error loading file!");
                using (StreamWriter sw = File.CreateText(path))
                { }
            }
            
            using (StreamReader sr = File.OpenText(path))
            {
                string graphicElement;
                while ((graphicElement = sr.ReadLine()) != null)
                {
                   
                    string[] temp1 = graphicElement.Split(',');
                    GraphicElement shape = new GraphicElement(temp1[0], Convert.ToInt32(temp1[1]), Convert.ToInt32(temp1[2]), Convert.ToInt32(temp1[3]), Convert.ToInt32(temp1[4]), temp1[5]);
                    shapes.Add(shape);
                }
            }
          
            return shapes;

           

        }
        public static List<FloorElement> ReadFloor()
        {
            List<FloorElement> floors = new List<FloorElement>();


            string path = @"C:\Users\Maja\Desktop\psw\WellDevClinic\WpfApp\surgicalBranchesFloors.txt";

            
            if (!File.Exists(path))
            {
                Console.WriteLine("Error loading file!");
                using (StreamWriter sw = File.CreateText(path))
                { }
            }

            using (StreamReader sr = File.OpenText(path))
            {
                string floorElement;
                while ((floorElement = sr.ReadLine()) != null)
                {

                    string[] temp1 = floorElement.Split(',');
                    try
                    {
                        FloorElement shape = new FloorElement(temp1[0], temp1[1], Convert.ToInt32(temp1[2]), Convert.ToInt32(temp1[3]), Convert.ToInt32(temp1[4]), Convert.ToInt32(temp1[5]), Convert.ToInt32(temp1[6]),temp1[7]);
                        floors.Add(shape);
                    }
                    catch { }
                }
            }

            return floors;
        }

		public static List<FloorElement> ReadFloorMedical()
		{
            List<FloorElement> floors = new List<FloorElement>();

            string path = @"C:\Users\Maja\Desktop\psw\WellDevClinic\WpfApp\medicalCenter.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Error loading file!");
                using (StreamWriter sw = File.CreateText(path))
                {
                }
            }

            using (StreamReader sr = File.OpenText(path))
            {
                string floorElement;
                while ((floorElement = sr.ReadLine()) != null)
                {

                    string[] temp1 = floorElement.Split(',');
                    try
                    {
                        FloorElement shape = new FloorElement(temp1[0], temp1[1], Convert.ToInt32(temp1[2]), Convert.ToInt32(temp1[3]), Convert.ToInt32(temp1[4]), Convert.ToInt32(temp1[5]), Convert.ToInt32(temp1[6]),temp1[7]);
                        floors.Add(shape);
                    }
                    catch { }
                }
            }

            return floors;
        }

        public static List<FloorElement> ReadFloorPediatric()
        {
            List<FloorElement> floors = new List<FloorElement>();

            string path = @"C:\Users\Maja\Desktop\psw\WellDevClinic\WpfApp\pediatrics.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("Error loading file!");
                using (StreamWriter sw = File.CreateText(path))
                { }
            }

            using (StreamReader sr = File.OpenText(path))
            {
                string floorElement;
                while ((floorElement = sr.ReadLine()) != null)
                {

                    string[] temp1 = floorElement.Split(',');
                    try
                    {
                        FloorElement shape = new FloorElement(temp1[0], temp1[1], Convert.ToInt32(temp1[2]), Convert.ToInt32(temp1[3]), Convert.ToInt32(temp1[4]), Convert.ToInt32(temp1[5]), Convert.ToInt32(temp1[6]),temp1[7]);
                        floors.Add(shape);
                    }
                    catch { }
                }
            }

            return floors;
        }
        public List<GraphicElement> elements;
        private GraphicElement graphicElement;
        public List<GraphicElement> buildings;
        public List<int> floors;
        private List<FloorElement> floorElement;

        public List<GraphicElement> Elements
        {
            get { return elements; }
            set { elements = value; }
        }

        public GraphicElement GraphicElement
        {
            get { return graphicElement; }
            set { GraphicElement = value; }
        }


        public List<GraphicElement> Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

        public List<int> Floors
        {
            get { return floors; }
            set { floors = value; }
        }
        
        public List<FloorElement> FloorElements
        {
            get { return floorElement; }
            set { floorElement = value; }
        }

        public ShapeViewModel()
        {
            elements = new List<GraphicElement>();
            buildings = new List<GraphicElement>();
            floorElement = new List<FloorElement>();
            floors = new List<int>();
            floors.Add(0);
            floors.Add(1);
            floors.Add(2);
            elements = Read();
            foreach (GraphicElement element in elements)
            {
                if (element.Type.Equals("Zgrada"))
                    buildings.Add(element);
            }

        }
    }
}


