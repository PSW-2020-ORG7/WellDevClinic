using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.ViewModel
{
    public class RenovationFlowViewModel
    {
        RelocationEquipmentViewModel relocationEquipment = new RelocationEquipmentViewModel();
        public RenovationFlowViewModel()
        {

        }

        public async void RelocateEquipment(Renovation renovation, long roomId, DateTime date)
        {
            List<Room> rooms = await WpfClient.GetAllRooms();
            long storageId = 0;
            foreach (Room r in rooms)
            {
                if (r.RoomType.Name.Equals("storage room"))
                    storageId = r.Id;

            }
            string equipment = "";
            foreach (EquipmentStatistic e in renovation.Room.EquipmentStatistic)
            {
                equipment += e.Equipment.Name+ ",";
            }
            relocationEquipment.SearchRoomAvailability(roomId, storageId, date.AddHours(-3), equipment);
        }
    }
}
