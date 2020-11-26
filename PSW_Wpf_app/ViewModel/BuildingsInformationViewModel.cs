using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.ViewModel
{
    class BuildingsInformationViewModel
    {

        private List<FloorElement> floorElements;
        private List<FloorElement> floorElementsM;
        private List<FloorElement> floorElementsP;
        private string building;
        public List<GraphicElement> buildings;
        public List<GraphicElement> elements;

        string pathSurgical = @"~\..\..\..\surgicalBranchesFloors.txt";
        string pathMedical = @"~\..\..\..\medicalCenter.txt";
        string pathPediatrics = @"~\..\..\..\pediatrics.txt";

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

        public MyICommand SaveMedicalCommand { get; set; }
        public MyICommand SaveSurgicalCommand { get; set; }
        public MyICommand SavePediatricsCommand { get; set; }

        public void OnSaveMedical()
        {
            ShapeViewModel.WriteFloor(floorElementsM, pathMedical);
        }

        public void OnSaveSurgical()
        {
            ShapeViewModel.WriteFloor(floorElements, pathSurgical);
        }

        public void OnSavePediatrics()
        {
            ShapeViewModel.WriteFloor(floorElementsP, pathPediatrics);
        }


        public BuildingsInformationViewModel()
        {

            SaveMedicalCommand = new MyICommand(OnSaveMedical);
            SaveSurgicalCommand = new MyICommand(OnSaveSurgical);
            SavePediatricsCommand = new MyICommand(OnSavePediatrics);

            floorElements = new List<FloorElement>();

            floorElements = ShapeViewModel.ReadFloor(pathSurgical);
            floorElementsM = new List<FloorElement>();
            floorElementsP = new List<FloorElement>();
            floorElementsM = ShapeViewModel.ReadFloor(pathMedical);
            FloorElementsP = ShapeViewModel.ReadFloor(pathPediatrics);

        }
    
    }
}
