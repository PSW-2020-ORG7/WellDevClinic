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
        BindingList<DateTime> alternativeDates = new BindingList<DateTime>();

        public BindingList<DateTime> AlternativeDates
        {
            get
            {
                return alternativeDates;
            }
            set
            {
                alternativeDates = value;
                OnPropertyChanged("AlternativeDates");
            }
        }

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
            List<Renovation> renovation = await WpfClient.GetAllRenovation();
            foreach (Renovation r in renovation)
            {
                Renovation pair = null;
                foreach (Renovation r3 in renovation)
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
        public async void LoadRoomByEquipment(Equipment equip)
        {

            BindingList<Room> list = new BindingList<Room>(await WpfClient.GetRoomsByEquipment(equip));
            Room_from = list;

        }

        public static long RoomId = -1;

        public async Task<bool> LoadExams(long roomId, DateTime dateTime)
        {
            Period period = new Period();
            period.StartDate = dateTime;
            period.EndDate = dateTime + new TimeSpan(0, 30, 0);
            Room room = await WpfClient.GetRoomById(roomId);
            BindingList<UpcomingExamination> list = new BindingList<UpcomingExamination>(await WpfClient.GetExaminationsByRoomAndPeriod(room, period));

            if (list.Count == 0) return true;
            foreach (UpcomingExamination item in list)
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
            catch { }

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
                Doctor d1, d2 = null;
                long id1 = -1, id2 = -1;
                
                foreach (BusinessDay item in buss)
                {

                    if (item.Room.Id == r1.Room.Id && item.Shift.StartDate <= r1.Period.StartDate && item.Shift.EndDate >= r1.Period.EndDate)
                    {

                        d1 = item.Doctor;
                        id1 = item.Id;
                    }

                    if (item.Room.Id == r2.Room.Id && item.Shift.StartDate <= r2.Period.StartDate && item.Shift.EndDate >= r2.Period.EndDate)
                    {
                        d2 = item.Doctor;
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
                RelocationEquipmentDTO relocation = new RelocationEquipmentDTO();

                relocation.Room_from = r1.Room.RoomType.Name;
                relocation.Room_to = r2.Room.RoomType.Name;
                relocation.Equip_name = r1.Description;
                relocation.Date = r1.Period.StartDate;

                renovations.Add(relocation);

            }
            else
            {
                MessageBox.Show("Choosen term is busy, please choose an alternative!");
                if (!isFree_from)
                    RoomId = room_from_id;
                else
                    RoomId = room_to_id;

                GetAlternativeExaminations(room_from_id, room_to_id, new DateTime(dt.Year, dt.Month, dt.Day, 7, 0, 0), new DateTime(dt.Year, dt.Month, dt.Day, 20, 0, 0));


            }


        }

        private async void GetAlternativeExaminations(long roomId1, long roomId2, DateTime dateTime1, DateTime dateTime2)
        {
            List<DateTime> all = new List<DateTime>();
            Period period = new Period();
            period.StartDate = dateTime1;
            period.EndDate = dateTime2 + new TimeSpan(0, 30, 0);
            for (DateTime dt = dateTime1; dt < dateTime2; dt += new TimeSpan(0, 30, 0))
            {
                all.Add(dt);
            }
            try
            {
                Room room1 = await WpfClient.GetRoomById(roomId1);
                Room room2 = await WpfClient.GetRoomById(roomId2);
                List<UpcomingExamination> list1 = new List<UpcomingExamination>(await WpfClient.GetExaminationsByRoomAndPeriod(room1, period));
                List<UpcomingExamination> list2 = new List<UpcomingExamination>(await WpfClient.GetExaminationsByRoomAndPeriod(room2, period));

                List<DateTime> finale = new List<DateTime>();

                if (list1.Count == 0 && list2.Count == 0)
                    finale = all;
                else
                    foreach (DateTime item in all)
                    {
                        if (list1.Find(x => x.Period.StartDate == item) != null)
                            continue;
                        if (list2.Find(x => x.Period.StartDate == item) != null)
                            continue;

                        finale.Add(item);
                    }
                AlternativeDates = new BindingList<DateTime>(finale);
            }
            catch { MessageBox.Show("Error while loading alternative terms"); }
        }


    }
}
