using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSW_Wpf_app.ViewModel
{
    class SearchResultViewModel : BindableBase
    {

        private List<FloorElement> searchedObjectresults;
        private List<FloorElement> floorSurgical;
        private List<FloorElement> floorsMedical;
        private List<FloorElement> floorsPediatrics;

        string pathSurgical = "../../../Data/surgicalBranchesFloors.txt";
        string pathMedical = "../../../Data/medicalCenter.txt";
        string pathPediatrics = "../../../Data/pediatrics.txt";

        public List<FloorElement> SearchedObjectresults
        {
            get { return searchedObjectresults; }
            set { searchedObjectresults = value; }
        }

        public SearchResultViewModel(string searchedObject)
        {
            searchedObjectresults = new List<FloorElement>();
            floorSurgical = ShapeViewModel.ReadFloor(pathSurgical);
            floorsMedical = ShapeViewModel.ReadFloor(pathMedical);
            floorsPediatrics = ShapeViewModel.ReadFloor(pathPediatrics);

            
            List<FloorElement> allFloors = floorSurgical.Concat(floorsMedical).Concat(floorsPediatrics).ToList();

            foreach (FloorElement floor in allFloors)
            {
                if (floor.Type.Equals(searchedObject) || (floor.Name.Equals(searchedObject)))
                {
                    searchedObjectresults.Add(floor);
                }
            }
        }
    }
}
