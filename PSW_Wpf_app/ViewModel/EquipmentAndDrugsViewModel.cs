using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace PSW_Wpf_app.ViewModel
{
    public class EquipmentAndDrugsViewModel : BindableBase
    {
        BindingList<Equipment> equipments = new BindingList<Equipment>();
        BindingList<Drug> drugs;
        public static Equipment SelectedEquipment { get; set; }
        public static Drug SelectedDrug { get; set; }

        public static MyICommand<object> SearchCommand { get; set; }

        public BindingList<Equipment> Equipments
        {
            get
            {
                return equipments;
            }
            set
            {
                equipments = value;
                OnPropertyChanged("Equipments");
            }

        }

        public BindingList<Drug> Drugs
        {
            get
            {

                return drugs;
            }
            set
            {
                drugs = value;
                OnPropertyChanged("Drugs");
            }

        }

        private async void OnSearch(object param)
        {
            bool isDrug = bool.Parse(((string)param).Split('_')[0]);
            string search = ((string)param).Split('_')[1];
            if (!isDrug)
            {
                List<Equipment> temp = new List<Equipment>(await WpfClient.GetAllEquipment());
                Equipments = new BindingList<Equipment>();
                foreach (Equipment item in temp)
                {
                    if (item.Name == search)
                    {
                        Equipments.Add(item);
                        return;
                    }
                }

            }
            else
            {
                List<Drug> temp = new List<Drug>(await WpfClient.GetAllDrug());
                Drugs = new BindingList<Drug>();
                foreach (Drug item in temp)
                {
                    if (item.Name == search)
                    {
                        Drugs.Add(item);
                        return;
                    }
                }
            }
        }
        public EquipmentAndDrugsViewModel()
        {
            SearchCommand = new MyICommand<object>(OnSearch);
            LoadEquipments();
            LoadDrugs();
        }
        private async void LoadEquipments()
        {
            Equipments = new BindingList<Equipment>(await WpfClient.GetAllEquipment());
        }

        private async void LoadDrugs()
        {
            Drugs = new BindingList<Drug>(await WpfClient.GetAllDrug());
        }
    }
}
