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
        
        public EquipmentAndDrugsViewModel()
        {
            Load();
        }
        private async void Load()
        {
            Equipments = new BindingList<Equipment>(await WpfClient.GetAllEquipment());
        }
    }
}
