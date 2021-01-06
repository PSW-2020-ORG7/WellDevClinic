using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PSW_Wpf_app.ViewModel
{
    class RelocationEquipmentViewModel : BindableBase
    {

        BindingList<Equipment> equipments = new BindingList<Equipment>();
        BindingList<Room> room_from = new BindingList<Room>();
        BindingList<Room> room_to = new BindingList<Room>();
        BindingList<RelocationEquipmentDTO> renovations = new BindingList<RelocationEquipmentDTO>();



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
        public BindingList<RelocationEquipmentDTO> Renovations
        {
            get
            {
                return renovations;
            }
            set
            {
                renovations = value;
                OnPropertyChanged("Renovations");
            }
        }

        public RelocationEquipmentViewModel()
        {
            LoadEquipments();
            LoadRenovations();

        }

        private async void LoadRenovations()
        {
            List<Renovation> ren = await WpfClient.GetAllRenovation();
            foreach (Renovation r in ren)
            {
                Renovation pair = null;
                foreach (Renovation r3 in ren)
                {
                    try
                    {
                        long id = long.Parse(r3.Description);
                        if (id == r.Id)
                        {
                            pair = r3;
                            break;
                        }
                    }

                    catch (Exception e) { continue; }

                }
                if (pair != null)
                {
                    RelocationEquipmentDTO relocation = new RelocationEquipmentDTO();
                    relocation.Room_from = r.Room.RoomType.Name;
                    relocation.Room_to = pair.Room.RoomType.Name;
                    relocation.Equip_name = r.Description;
                    relocation.Date = r.Period.StartDate;

                    renovations.Add(relocation);




                }
            }

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

        public static long RoomId = -1;

        public async Task<bool> LoadExams(long roomId, DateTime dateTime)
        {
            BindingList<Examination> list = new BindingList<Examination>(await WpfClient.GetExaminationsByRoomAndPeriod(roomId, dateTime));

            if (list.Count == 0) return true;
            foreach (Examination item in list)
            {
                if (item.Period.StartDate == dateTime)
                    return false;
            }

            return true;


        }

        public async void SearchRoomAvailability(long room_from_id, long room_to_id, DateTime dt, string equipment)
        {
            bool isFree_from = false, isFree_to = false;
            try
            {
                isFree_from = await LoadExams(room_from_id, dt);
                isFree_to = await LoadExams(room_to_id, dt);
            }
            catch
            { }

            if (isFree_from && isFree_to)
            {

                Renovation r1 = new Renovation();
                r1.Room = await WpfClient.GetRoomById(room_from_id);
                r1.Period = new Period() { StartDate = dt, EndDate = dt + new TimeSpan(0, 30, 0) };
                r1.Description = equipment;

                r1 = await WpfClient.Save(r1);


                Renovation r2 = new Renovation();
                r2.Room = await WpfClient.GetRoomById(room_to_id);
                r2.Period = new Period() { StartDate = dt, EndDate = dt + new TimeSpan(0, 30, 0) };
                r2.Description = r1.Id.ToString();

                await WpfClient.Save(r2);
                List<BusinessDay> buss = await WpfClient.GetAllBusinessDay();
                Doctor d1 = null;
                Doctor d2 = null;
                long id1 = -1;
                long id2 = -1;
                foreach (BusinessDay item in buss)
                {

                    if (item.room.Id == r1.Room.Id && item.Shift.StartDate <= r1.Period.StartDate && item.Shift.EndDate >= r1.Period.EndDate)
                    {

                        d1 = item.doctor;
                        id1 = item.Id;
                    }

                    if (item.room.Id == r2.Room.Id && item.Shift.StartDate <= r2.Period.StartDate && item.Shift.EndDate >= r2.Period.EndDate)
                    {
                        d2 = item.doctor;
                        id2 = item.Id;


                    }
                }


                List<Period> periods = new List<Period>();
                periods.Add(r1.Period);
                if (id1 != -1)
                    await WpfClient.MarkAsOccupied(periods, id1);
                if (id2 != -1)
                    await WpfClient.MarkAsOccupied(periods, id2);

                MessageBox.Show("You have successfully scheduled equipment relocation!");
                RelocationEquipmentDTO rel = new RelocationEquipmentDTO();

                rel.Room_from = r1.Room.RoomType.Name;
                rel.Room_to = r2.Room.RoomType.Name;
                rel.Equip_name = r1.Description;
                rel.Date = r1.Period.StartDate;

                renovations.Add(rel);

            }
            else
            {
                MessageBox.Show("Choosen term is busy, please choose an alternative!");
                if (!isFree_from)
                    RoomId = room_from_id;
                else
                    RoomId = room_to_id;

            }



        }



    }
}
