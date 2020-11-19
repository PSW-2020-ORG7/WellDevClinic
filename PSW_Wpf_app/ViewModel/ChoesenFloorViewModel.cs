using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;
using WpfApp.Model;
using System.Windows;
using System.Windows.Input;
using PSW_Wpf_app.Drawing;

namespace WpfApp.ViewModel
{
    public class ChoesenFloorViewModel : BindableBase
    {

        

        List<FloorElement> floors = new List<FloorElement>();

        private string choosenBuilding;
        public string ChoosenBuilding
        {
            get { return choosenBuilding; }
            set
            {
                SetField(ref choosenBuilding, value);
            }
        }

        private int choosenFloor;
        public int ChoosenFloor
        {
            get { return choosenFloor; }
            set
            {
                SetField(ref choosenFloor, value);
            }
        }

        public ChoesenFloorViewModel(Canvas canvasFloor, string buil, int floor)
        {
            choosenBuilding = buil;
            choosenFloor = floor;
            floors = getFloor(ChoosenBuilding);

            DrawFloorElement floorDrawer = new DrawFloorElement(canvasFloor);

            foreach (FloorElement f in floors)
            {
                if (f.Floor.Equals(choosenFloor))
                {
                    Shape shape = floorDrawer.DrawElement(f);
                    shape.MouseDown += openInfo;
                    canvasFloor.Children.Add(shape);
                }
            }
        }

        private List<FloorElement> getFloor(object name)
        {
            string pathSurgical = "../../../Data/surgicalBranchesFloors.txt";
            string pathMedical = "../../../Data/medicalCenter.txt";
            string pathPediatrics = "../../../Data/pediatrics.txt";

            List<FloorElement> floors = new List<FloorElement>();

            switch (ChoosenBuilding)
            {
                case "Surgical":
                    floors = ShapeViewModel.ReadFloor(pathSurgical);
                    break;
                case "MedicalCenter":
                    floors = ShapeViewModel.ReadFloor(pathMedical);
                    break;
                case "Pediatrics":
                    floors = ShapeViewModel.ReadFloor(pathPediatrics);
                    break;
            }

            return floors;
        }
        void openInfo(object sender, MouseButtonEventArgs e)
        {
            floors = getFloor(ChoosenBuilding);

            var mouseWasDownOn = e.Source as FrameworkElement;
            if (mouseWasDownOn != null)
            {
                string elementName = mouseWasDownOn.Name;
                foreach (FloorElement f in floors)
                {
                    if (elementName.Equals(f.Name))
                        MessageBox.Show(string.Format("additional information: {0}\n", f.Info));
                }
            }
        }
    }
}
