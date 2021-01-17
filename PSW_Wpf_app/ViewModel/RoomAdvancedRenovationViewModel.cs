using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PSW_Wpf_app.ViewModel
{
    class RoomAdvancedRenovationViewModel : BindableBase
    {

        BindingList<FloorElement> room = new BindingList<FloorElement>();

        private FloorElement floor;
        public RoomAdvancedRenovationViewModel(FloorElement floor)
        {
            this.floor = floor;
            LoadRoom();


        }


        public BindingList<FloorElement> Room
        {
            get
            {
                return room;
            }
            set
            {
                room = value;
                OnPropertyChanged("Room");
            }
        }

        public void LoadRoom()
        {
            BindingList<FloorElement> filtered_list = new BindingList<FloorElement>();
            List<FloorElement> list = new List<FloorElement>();

            string pathSurgical = "../../../Data/surgicalBranchesFloors.txt";
            string pathMedical = "../../../Data/medicalCenter.txt";
            string pathPediatrics = "../../../Data/pediatrics.txt";



            switch (floor.BuildingName)
            {
                case "Surgical":
                    list = ShapeViewModel.ReadFloor(pathSurgical);
                    break;
                case "MedicalCenter":
                    list = ShapeViewModel.ReadFloor(pathMedical);
                    break;
                case "Pediatrics":
                    list = ShapeViewModel.ReadFloor(pathPediatrics);
                    break;
            }

        }
    }
}
