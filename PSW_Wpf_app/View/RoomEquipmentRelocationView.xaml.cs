using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using PSW_Wpf_app.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PSW_Wpf_app.View
{
    public partial class RoomEquipmentRelocationView : UserControl
    {
        BindingList<RelocationEquipmentDTO> relocations = new BindingList<RelocationEquipmentDTO>();
        public RoomEquipmentRelocationView(FloorElement floor)
        {
            InitializeComponent();
            LoadRenovationForRoom(floor);
            
        }

        private async void LoadRenovationForRoom(FloorElement f)
        {
            List<Renovation> renovations = await WpfClient.GetAllRenovation();
            List<RelocationEquipmentDTO> relocations = new List<RelocationEquipmentDTO>();
            RelocationEquipmentDTO relocation = new RelocationEquipmentDTO();
            foreach(Renovation r in renovations)
            {

                if(r.RenovationStatus.Equals(RenovationStatus.Traje) && r.Room.Id.Equals(f.RoomId))
                {
                    int n;
                    bool isNumeric = int.TryParse(r.Description, out n);
                    if (isNumeric)
                        relocation = FindRoomTo(renovations, r, n);
                    else
                        relocation = FindRoomFrom(renovations, r);

                    relocations.Add(relocation);
                }
            }

            equipmentRelocation.ItemsSource = relocations;
        }

        private static RelocationEquipmentDTO FindRoomFrom(List<Renovation> renovations, Renovation r)
        {
            RelocationEquipmentDTO relocation = new RelocationEquipmentDTO();
            relocation.Room_from = r.Room.RoomCode;
            relocation.Equip_name = r.Description;
            relocation.Date = r.Period.StartDate;
            relocation.Renovations_id.Add(r.Id);
            foreach (Renovation re in renovations)
            {
                if (re.RenovationStatus.Equals(RenovationStatus.Traje) && re.Description.Equals(r.Id.ToString()))
                {
                    relocation.Room_to = re.Room.RoomCode;
                    relocation.Renovations_id.Add(re.Id);
                }
            }

            return relocation;
        }

        private static RelocationEquipmentDTO FindRoomTo(List<Renovation> renovations, Renovation r, int n)
        {
            RelocationEquipmentDTO relocation = new RelocationEquipmentDTO();
            relocation.Room_to = r.Room.RoomCode;
            relocation.Date = r.Period.StartDate;
            relocation.Renovations_id.Add(r.Id);
            foreach (Renovation re in renovations)
            {
                if (re.RenovationStatus.Equals(RenovationStatus.Traje) && re.Id.Equals(n))
                {
                    relocation.Room_from = re.Room.RoomCode;
                    relocation.Equip_name = re.Description;
                    relocation.Renovations_id.Add(re.Id);
                }
            }

            return relocation;

        }

        private async void Cancel_Click(object sender, RoutedEventArgs e)
        {
            RelocationEquipmentDTO relocation = (RelocationEquipmentDTO)equipmentRelocation.SelectedItem;
            List<Renovation> renovations = new List<Renovation>();
            renovations.Add(await WpfClient.GetRenovationById(relocation.Renovations_id[0]));
            renovations.Add(await WpfClient.GetRenovationById(relocation.Renovations_id[1]));
            renovations[0].RenovationStatus = RenovationStatus.Otkazano;
            renovations[1].RenovationStatus = RenovationStatus.Otkazano;
            WpfClient.EditRenovation(renovations[0]);
            WpfClient.EditRenovation(renovations[1]);
            MessageBox.Show("You have successfully canceled equipment relocation !");
        }
    }
}
