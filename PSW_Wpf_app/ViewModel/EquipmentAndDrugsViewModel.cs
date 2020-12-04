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

        public EquipmentAndDrugsViewModel()
        {
            Load();
        }
        private async void Load()
        {
            Equipments = new BindingList<Equipment>(await WpfClient.GetAllEquipment());
            Drugs = new BindingList<Drug>(await WpfClient.GetAllDrug());
        }
    }
}
