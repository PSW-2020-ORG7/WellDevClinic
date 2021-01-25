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


        private async void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //  Renovation renovation = (Renovation)equipmentRelocation.SelectedItem;
            // renovation.Status = RenovationStatus.Otkazano;
            //WpfClient.EditRenovation(renovation);
            /*  if(scheduledAppointments.SelectedItem != null)
              {
                  scheduledAppointments.Items.Remove(scheduledAppointments.SelectedItem);
              }*/
        }
        private static RelocationEquipmentDTO FindRoomFrom(List<Renovation> renovations, Renovation r)
        {
            RelocationEquipmentDTO relocation = new RelocationEquipmentDTO();
            relocation.Room_from = r.Room.RoomCode;
            relocation.Equip_name = r.Description;
            relocation.Date = r.Period.StartDate;
            foreach (Renovation re in renovations)
            {
                if (re.RenovationStatus.Equals(RenovationStatus.Traje) && re.Description.Equals(r.Id.ToString()))
                  relocation.Room_to = re.Room.RoomCode;

            }

            return relocation;
        }

        private static RelocationEquipmentDTO FindRoomTo(List<Renovation> renovations, Renovation r, int n)
        {
            RelocationEquipmentDTO relocation = new RelocationEquipmentDTO();
            relocation.Room_to = r.Room.RoomCode;
            relocation.Date = r.Period.StartDate;
            foreach (Renovation re in renovations)
            {
                if (re.RenovationStatus.Equals(RenovationStatus.Traje) && re.Id.Equals(n))
                {
                    relocation.Room_from = re.Room.RoomCode;
                    relocation.Equip_name = re.Description;
                }
            }

            return relocation;

        }
    }
}
