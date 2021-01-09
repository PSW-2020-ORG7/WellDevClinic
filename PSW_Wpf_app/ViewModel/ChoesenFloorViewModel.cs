using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;
using PSW_Wpf_app.Model;
using System.Windows;
using System.Windows.Input;
using PSW_Wpf_app.Drawing;
using System;
using PSW_Wpf_app.View;

namespace PSW_Wpf_app.ViewModel
{
    public class ChoesenFloorViewModel : BindableBase
    {

        List<FloorElement> floors = new List<FloorElement>();

        private string choosenBuilding;
        private string user;
        public string User
        {
            get { return user; }
            set { user = value; }

        }
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

        public ChoesenFloorViewModel(Canvas canvasFloor, String build, int floor, List<FloorElement> rooms, string userType)
        {
            user = userType;
            if (RelocationEquipmentViewModel.RoomId == -1 && EquipmentAndDrugsViewModel.SelectedEquipment == null && EquipmentAndDrugsViewModel.SelectedDrug == null && SearchResultViewModel.SelectedResult == null)
            {
                choosenBuilding = build;
                choosenFloor = floor;
                floors = getFloor(ChoosenBuilding);

                DrawFloorElement floorDrawer = new DrawFloorElement(canvasFloor);

                bool flag = false;
                foreach (FloorElement f in floors)
                {
                    flag = false;
                    if (f.Floor.Equals(choosenFloor))
                    {
                        foreach (FloorElement foundRoom in rooms)
                        {
                            if (foundRoom.Floor == choosenFloor && foundRoom.Name == f.Name)
                            {
                                flag = true;
                            }
                        }

                        Shape shape = floorDrawer.DrawElement(f, flag);
                        shape.MouseDown += openInfo;
                        canvasFloor.Children.Add(shape);
                    }
                }
            }


            else if (SearchResultViewModel.SelectedResult != null)
            {
                choosenBuilding = build;
                choosenFloor = floor;
                floors = getFloor(ChoosenBuilding);

                DrawFloorElement floorDrawer = new DrawFloorElement(canvasFloor);

                bool flag = false;
                foreach (FloorElement f in floors)
                {
                    flag = false;
                    if (f.Floor.Equals(choosenFloor))
                    {
                        foreach (FloorElement foundRoom in rooms)
                        {
                            if (foundRoom.Floor == choosenFloor && foundRoom.Name == f.Name && SearchResultViewModel.SelectedResult.Name == f.Name)
                            {
                                flag = true;
                            }
                        }

                        Shape shape = floorDrawer.DrawElement(f, flag);
                        shape.MouseDown += openInfo;
                        canvasFloor.Children.Add(shape);
                    }
                }
                SearchResultViewModel.SelectedResult = null;

            }

            else if (EquipmentAndDrugsViewModel.SelectedEquipment != null)
            {
                choosenBuilding = build;
                choosenFloor = floor;
                floors = getFloor(ChoosenBuilding);

                DrawFloorElement floorDrawer = new DrawFloorElement(canvasFloor);

                bool flag = false;
                foreach (FloorElement f in floors)
                {
                    flag = false;
                    if (f.Floor.Equals(choosenFloor))
                    {
                        if (f.Equipments.Exists(x => x.Id == EquipmentAndDrugsViewModel.SelectedEquipment.Id))
                        {
                            flag = true;
                        }


                        Shape shape = floorDrawer.DrawElement(f, flag);
                        shape.MouseDown += openInfo;
                        canvasFloor.Children.Add(shape);
                    }
                }
                EquipmentAndDrugsViewModel.SelectedEquipment = null;
            }

            else if (EquipmentAndDrugsViewModel.SelectedDrug != null)
            {
                choosenBuilding = build;
                choosenFloor = floor;
                floors = getFloor(ChoosenBuilding);

                DrawFloorElement floorDrawer = new DrawFloorElement(canvasFloor);

                bool flag = false;
                foreach (FloorElement f in floors)
                {
                    flag = false;
                    if (f.Floor.Equals(choosenFloor))
                    {
                        if (f.Drugs.Exists(x => x.Id == EquipmentAndDrugsViewModel.SelectedDrug.Id))
                        {
                            flag = true;
                        }


                        Shape shape = floorDrawer.DrawElement(f, flag);
                        shape.MouseDown += openInfo;
                        canvasFloor.Children.Add(shape);
                    }
                }
                EquipmentAndDrugsViewModel.SelectedDrug = null;
            }

            else if (RelocationEquipmentViewModel.RoomId != -1)
            {
                choosenBuilding = build;
                choosenFloor = floor;
                floors = getFloor(ChoosenBuilding);

                DrawFloorElement floorDrawer = new DrawFloorElement(canvasFloor);

                bool flag = false;
                foreach (FloorElement f in floors)
                {
                    flag = false;
                    if (f.Floor.Equals(choosenFloor))
                    {
                        if (f.RoomId == RelocationEquipmentViewModel.RoomId)
                        {
                            
                            flag = true;

                        }

                        Shape shape = floorDrawer.DrawElement(f, flag);
                        shape.MouseDown += openInfo;
                        canvasFloor.Children.Add(shape);
                    }
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
                    {
                        if (user == "patient")
                        {
                            MessageBox.Show(string.Format("additional information: {0}\n", f.Info));
                        }
                        else
                        {
                            RoomStuffView roomStuffView = new RoomStuffView(f);
                            roomStuffView.Show();
                        }
                    }
                        
                    }
                }
            }
        }
    }
