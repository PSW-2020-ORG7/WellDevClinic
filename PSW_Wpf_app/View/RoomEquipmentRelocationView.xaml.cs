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
            List<Renovation> renovation = await WpfClient.GetAllRenovation();
            RelocationEquipmentDTO relocation = new RelocationEquipmentDTO();
            foreach (Renovation r in renovation)
            {
                if (r.Room.Id.Equals(f.RoomId) && r.Status.Equals(RenovationStatus.Otkazano))
                {
                Renovation pair = null;
                foreach (Renovation re in renovation)
                {
                    try
                    {
                        long id = long.Parse(re.Description);
                        if (id == r.Id)
                        {
                            pair = re;
                            break;
                        }
                    }

                    catch (Exception e) { continue; }

                }
                    
                    relocation.Room_from = r.Room.RoomCode;
                    relocation.Room_to = pair.Room.RoomCode;
                    relocation.Date = r.Period.StartDate;

                    relocations.Add(relocation);
                }

            }

            equipmentRelocation.ItemsSource = relocations;
        }

        private async void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Renovation renovation = (Renovation)equipmentRelocation.SelectedItem;
            renovation.Status = RenovationStatus.Otkazano;
            WpfClient.EditRenovation(renovation);
            /*  if(scheduledAppointments.SelectedItem != null)
              {
                  scheduledAppointments.Items.Remove(scheduledAppointments.SelectedItem);
              }*/
        }
    }
}
