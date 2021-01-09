using PSW_Wpf_app.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PSW_Wpf_app.ViewModel
{
    class RelocationEquipmentViewModel : BindableBase
    {

        BindingList<Equipment> equipments = new BindingList<Equipment>();
        BindingList<Room> room_from = new BindingList<Room>();
        BindingList<Room> room_to = new BindingList<Room>();



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
        public BindingList<Room> Room_from
        {
            get
            {
                return room_from;
            }
            set
            {
                room_from = value;
                OnPropertyChanged("Room_from");
            }
        }

        public BindingList<Room> Room_to
        {
            get
            {
                return room_to;
            }
            set
            {
                room_to = value;
                OnPropertyChanged("Room_to");
            }
        }

        public RelocationEquipmentViewModel()
        {
            LoadEquipments();
        }

        private async void LoadEquipments()
        {
            Equipments = new BindingList<Equipment>(await WpfClient.GetAllEquipment());
        }

        public async void LoadRoom(Room room_from)
        {
            BindingList<Room> filtered_list = new BindingList<Room>();
            BindingList<Room> list = new BindingList<Room>(await WpfClient.GetAllRooms());

            foreach (Room room in list)
            {
                if (room.Id != room_from.Id)
                    filtered_list.Add(room);
            }
            Room_to = filtered_list;


        }
        public async void LoadRoomByEquipment(long equipId)
        {
            BindingList<Room> list = new BindingList<Room>(await WpfClient.GetRoomsByEquipment(equipId));
            Room_from = list;


        }


    }
}
