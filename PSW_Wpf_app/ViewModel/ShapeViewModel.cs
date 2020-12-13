using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PSW_Wpf_app.Model;

namespace PSW_Wpf_app.ViewModel
{
    public class ShapeViewModel
    {
        string pathMedical = "../../../Data/medicalCenter.txt";

        public static List<GraphicElement> Read()
        {
            List<GraphicElement> shapes = new List<GraphicElement>();

            string path = @"../../../Data/externalMap.txt";


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
                    GraphicElement shape = new GraphicElement(temp1[0], Convert.ToInt32(temp1[1]), Convert.ToInt32(temp1[2]), Convert.ToInt32(temp1[3]), Convert.ToInt32(temp1[4]), temp1[5], temp1[6]);
                    shapes.Add(shape);
                }
            }

            return shapes;

        }
        public static List<FloorElement> ReadFloor(string path)
        {
            List<FloorElement> floors = new List<FloorElement>();

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
                        FloorElement shape = new FloorElement(temp1[0], temp1[1], Convert.ToInt32(temp1[2]), Convert.ToInt32(temp1[3]), Convert.ToInt32(temp1[4]), Convert.ToInt32(temp1[5]), Convert.ToInt32(temp1[6]), temp1[7], temp1[8]);

                        if (temp1.Count() == 11)
                        {
                            string[] equipments = temp1[9].Split(':', '-');
                            for (int i = 0; i < equipments.Count() - 1; i += 3)
                            {
                                shape.Equipments.Add(new Client.Equipment() { Id = int.Parse(equipments[(i % 4) + 1]), Name = equipments[(i % 4) + 2], Amount = int.Parse(equipments[(i % 4) + 3]) });
                            }

                            string[] drugs = temp1[10].Split(':', '-');
                            for (int i = 0; i < drugs.Count() - 1; i += 3)
                            {
                                shape.Drugs.Add(new Client.Drug() { Id = int.Parse(drugs[(i % 4) + 1]), Name = drugs[(i % 4) + 2], Amount = int.Parse(drugs[(i % 4) + 3]) });
                            }

                        }

                            floors.Add(shape);
                        
                    }
                    catch { }
                }
            }

            return floors;
        }

        public static void WriteFloor(List<FloorElement> elements, string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Error loading file!");

            }
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (FloorElement item in elements)
                {
                    sw.WriteLine($"{item.Type},{item.Name},{item.Width},{item.Height},{item.X},{item.Y},{item.Floor},{item.Info}");
                }
            }
        }


        private List<GraphicElement> elements;
        private List<GraphicElement> buildings;
        private List<FloorElement> floors;
        private List<int> floorsCount;

        public List<int> FloorsCount
        {
            get { return floorsCount; }
            set { floorsCount = value; }
        }

        public List<GraphicElement> Elements
        {
            get { return elements; }
            set { elements = value; }
        }

        public List<GraphicElement> Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

        public List<FloorElement> Floors
        {
            get { return floors; }
            set { floors = value; }
        }

        public ShapeViewModel()
        {
            elements = new List<GraphicElement>();
            buildings = new List<GraphicElement>();
            floors = new List<FloorElement>();
            elements = Read();
            floors = ReadFloor(pathMedical);
            floorsCount = new List<int>();
            int maxFloor = 0;
            foreach (GraphicElement element in elements)
            {
                if (element.Type.Equals("Building"))
                {
                    buildings.Add(element);
                    foreach (FloorElement floor in floors)
                    {
                        if (maxFloor < floor.Floor)
                            maxFloor = floor.Floor;
                    }
                }
            }
            for (int i = 0; i <= maxFloor; i++)
            {
                floorsCount.Add(i);
            }

        }
    }
}


