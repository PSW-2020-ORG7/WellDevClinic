using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;
using WpfApp.View;

namespace WpfApp.ViewModel
{
    public class BuildingsInformationViewModel : BindableBase
    {
        private List<FloorElement> floorElements;
        private List<FloorElement> floorElementsM;
        private List<FloorElement> floorElementsP;
        private string building;
        public List<GraphicElement> buildings;
        public List<GraphicElement> elements;

        public string Building
        {
            get { return building; }
            set { building = value; }
        }

        public List<GraphicElement> Elements
        {
            get { return elements; }
            set { elements = value; }
        }

        public List<FloorElement> FloorElements
        {
            get { return floorElements; }
            set { floorElements = value; }
        }

        public List<FloorElement> FloorElementsM
        {
            get { return floorElementsM; }
            set { floorElementsM = value; }
        }

        public List<FloorElement> FloorElementsP
        {
            get { return floorElementsP; }
            set { floorElementsP = value; }
        }

        public List<GraphicElement> Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

        public BuildingsInformationViewModel()
        {
            //building = build;
            floorElements = new List<FloorElement>();
           /* buildings = new List<GraphicElement>();
            elements = ShapeViewModel.Read();
            foreach (GraphicElement element in elements)
            {
                if (element.Type.Equals("Zgrada"))
                    buildings.Add(element);

               // Console.WriteLine(buildings.Count);
            }
            
                foreach (GraphicElement b in buildings)
                {
               // Console.WriteLine(b.Name);
                if (b.Name.Equals("Surgical"))
                    {
                        Console.WriteLine("Usaooo");
                        Building = b.Name;
                        floorElements = ShapeViewModel.ReadFloor();
                    }
                    else if (b.Name.Equals("MedicalCenter"))
                    {
                        Building = b.Name;
                        floorElements = ShapeViewModel.ReadFloorMedical();
                    }
                    else if (b.Name.Equals("Pediatrics"))
                    {
                        Building = b.Name;
                        floorElements = ShapeViewModel.ReadFloorPediatric();
                    }
                }**/
            
            floorElements= ShapeViewModel.ReadFloor();
            floorElementsM = new List<FloorElement>();
            floorElementsP = new List<FloorElement>();
            floorElementsM = ShapeViewModel.ReadFloorMedical();
            FloorElementsP = ShapeViewModel.ReadFloorPediatric();

        }
    }
}
