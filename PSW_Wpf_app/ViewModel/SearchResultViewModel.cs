using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PSW_Wpf_app.ViewModel
{
    public class SearchResultViewModel : BindableBase
    {

        private List<RoomWrapper> searchResults;
        private List<FloorElement> floorSurgical;
        private List<FloorElement> floorsMedical;
        private List<FloorElement> floorsPediatrics;

        string pathSurgical = "../../../Data/surgicalBranchesFloors.txt";
        string pathMedical = "../../../Data/medicalCenter.txt";
        string pathPediatrics = "../../../Data/pediatrics.txt";

        public List<RoomWrapper> SearchResults
        {
            get { return searchResults; }
            set { searchResults = value; }
        }

        public SearchResultViewModel(string searchedObject)
        {
            SearchResults = new List<RoomWrapper>();
            floorSurgical = ShapeViewModel.ReadFloor(pathSurgical);
            floorsMedical = ShapeViewModel.ReadFloor(pathMedical);
            floorsPediatrics = ShapeViewModel.ReadFloor(pathPediatrics);

            
            List<FloorElement> allFloors = floorSurgical.Concat(floorsMedical).Concat(floorsPediatrics).ToList();

            foreach (FloorElement floor in floorSurgical)
            {
                if (floor.Type.Equals(searchedObject) || (floor.Name.Equals(searchedObject)))
                {
                    searchResults.Add(new RoomWrapper(floor,"Surgical"));
                }
            }

            foreach (FloorElement floor in floorsMedical)
            {
                if (floor.Type.Equals(searchedObject) || (floor.Name.Equals(searchedObject)))
                {
                    searchResults.Add(new RoomWrapper(floor, "MedicalCenter"));
                }
            }

            foreach (FloorElement floor in floorsPediatrics)
            {
                if (floor.Type.Equals(searchedObject) || (floor.Name.Equals(searchedObject)))
                {
                    searchResults.Add(new RoomWrapper(floor, "Pediatrics"));
                }
            }

            if (searchResults.Count == 0)
            {
                MessageBox.Show("Object doesn't exist!");
            }
        }
    }
}
