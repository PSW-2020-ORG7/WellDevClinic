using PSW_Wpf_app.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PSW_Wpf_app.ViewModel
{
    public class EquipmentAndDrugsViewModel : BindableBase
    {
        BindingList<Equipment> equipments = new BindingList<Equipment>();
        BindingList<Drug> drugs;
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

        private void OnSearch(object param)
        {
            bool isDrug = bool.Parse(((string)param).Split('_')[0]);
            string search = ((string)param).Split('_')[1];
            if (!isDrug)
            {
                List<Equipment> temp = new List<Equipment>(equipments);
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
                List<Drug> temp = new List<Drug>(drugs);
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
            Load();
        }
        private async void Load()
        {
            Equipments = new BindingList<Equipment>(await WpfClient.GetAllEquipment());
            Drugs = new BindingList<Drug>(await WpfClient.GetAllDrug());
        }
    }
}
