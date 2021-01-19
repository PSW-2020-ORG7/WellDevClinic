using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace PSW_Wpf_app.ViewModel
{
    class RoomAdvancedRenovationViewModel : BindableBase
    {

        BindingList<FloorElement> room = new BindingList<FloorElement>();
        BindingList<DateTime> alternativeDates = new BindingList<DateTime>();
        List<Renovation> renovation = null;

        private FloorElement floor;
        public RoomAdvancedRenovationViewModel(FloorElement floor)
        {
            this.floor = floor;
            LoadRoom();


        }


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


        public BindingList<FloorElement> Room
        {
            get
            {
                return room;
            }
            set
            {
                room = value;
                OnPropertyChanged("Room");
            }
        }

        public void LoadRoom()
        {
            BindingList<FloorElement> filtered_list = new BindingList<FloorElement>();
            List<FloorElement> list = new List<FloorElement>();

            string pathSurgical = "../../../Data/surgicalBranchesFloors.txt";
            string pathMedical = "../../../Data/medicalCenter.txt";
            string pathPediatrics = "../../../Data/pediatrics.txt";



            switch (floor.BuildingName)
            {
                case "Surgical":
                    list = ShapeViewModel.ReadFloor(pathSurgical);
                    break;
                case "MedicalCenter":
                    list = ShapeViewModel.ReadFloor(pathMedical);
                    break;
                case "Pediatrics":
                    list = ShapeViewModel.ReadFloor(pathPediatrics);
                    break;
            }
            foreach(FloorElement fe in list)
            {
                int xMin;
                int xMax;
                int yMin;
                int yMax;
                int xDif;
                int yDif;

                if (fe.Floor != floor.Floor)
                    continue;
                if (fe.X == floor.X && fe.Y == floor.Y)
                    continue;
                if (fe.Type.CompareTo("room") != 0)
                    continue;

                xMin = minCoords(fe.X + fe.Width, floor.X + floor.Width);
                xMax = maxCoords(fe.X, floor.X);

                yMin = minCoords(fe.Y + fe.Height, floor.Y + floor.Height);
                yMax = maxCoords(fe.Y, floor.Y);

                xDif = xMax - xMin;
                yDif = yMax - yMin;

                if (xDif < 5 && yDif < 5)
                {

                    filtered_list.Add(fe);
                }

                Room = filtered_list;

            }

        }

        private int minCoords(int x1, int x2)
        {

            return x1 < x2 ? x1 : x2;


        }
        private int maxCoords(int x1, int x2)
        {

            return x1 > x2 ? x1 : x2;


        }

        public async Task<bool> CheckRenovation(long roomId, DateTime dateTime)
        {
            if (renovation == null)
            {
                renovation = new List<Renovation>(await WpfClient.GetAllRenovation());
            }
            foreach (Renovation ren in renovation)

            {

                if (ren.Room.Id == roomId && dateTime.Date >= ren.Period.StartDate.Date && dateTime.Date <= ren.Period.EndDate.Date)
                {

                    return false;
                }


            }
            return true;

        }


        public async Task<bool> LoadExams(long roomId, DateTime dateTime)
        {
            BindingList<Examination> list = new BindingList<Examination>(await WpfClient.GetExaminationsByRoomAndPeriod(roomId, dateTime));

            if (list.Count == 0) return true;


            return false;


        }

        public async Task<bool> Scheduling(DateTime d1, DateTime d2, string tip, FloorElement f)
        {

            Room rom = await GetRoom(floor);
            Room mergingRoom = await GetRoom(f);

            bool free = await checkIsFree(d1, d2, rom, mergingRoom);
            if (!free)
                return false;

            Renovation r1 = new Renovation();
            r1.Room = rom;
            r1.Status = RenovationStatus.Zakazano;

            r1.Period = new Period() { StartDate = d1, EndDate = d2 };
            r1.Description = "";

            r1 = await WpfClient.Save(r1);
            if (f != null)
            {
                Renovation r2 = new Renovation();
                r2.Room = mergingRoom;
                r2.Status = RenovationStatus.Zakazano;
                r2.Period = new Period() { StartDate = d1, EndDate = d2 };
                r2.Description = r1.Id.ToString();

                await WpfClient.Save(r2);
            }
            List<BusinessDay> buss = await WpfClient.GetAllBusinessDay();

            foreach (BusinessDay bd in buss)
            {
                if (bd.Shift.StartDate >= d1 && bd.Shift.StartDate <= d2)
                {

                    if (bd.room.Id == rom.Id || (mergingRoom != null && mergingRoom.Id == bd.room.Id))
                    {
                        List<Period> periods = CreatePeriods(bd);
                        await WpfClient.MarkAsOccupied(periods, bd.Id);

                    }

                }
            }
            return true;
        }
        private List<Period> CreatePeriods(BusinessDay bd)
        {
            List<Period> periods = new List<Period>();

            for (DateTime dt = bd.Shift.StartDate + new TimeSpan(0, 30, 0); dt < bd.Shift.EndDate; dt += new TimeSpan(0, 30, 0))
            {
                Period p = new Period();
                p.StartDate = dt;
                p.EndDate = dt + new TimeSpan(0, 30, 0);
                periods.Add(p);


            }


            return periods;

        }



        public async void GetAlternativeExaminations(FloorElement fl, DateTime d1, DateTime d2)
        {

            BindingList<DateTime> alternative = new BindingList<DateTime>();
            Room room = await GetRoom(floor);
            Room mergingRoom = await GetRoom(fl);

            while (alternative.Count != 5)
            {

                bool free = await checkIsFree(d1, d2, room, mergingRoom);

                if (free)
                {
                    alternative.Add(d1);


                }
                d1 = d1.AddDays(1);
                d2 = d2.AddDays(2);


            }

            AlternativeDates = alternative;



        }
         private async Task<Room> GetRoom(FloorElement fe)
        {
            if (fe == null)
                return null;
            List<Room> list = new List<Room>(await WpfClient.GetAllRooms());

            Room rom = null;
            foreach (Room r in list)
            {
                if (r.RoomCode.CompareTo(fe.Name) == 0)

                    rom = r;

            }
            return rom;


        }

        private async Task<bool> checkIsFree(DateTime d1, DateTime d2, Room rom, Room mergingRoom) 
        
        {


            for (DateTime dt = d1; dt <= d2; dt = dt.AddDays(1))
            {
                bool isFree = await LoadExams(rom.Id, dt);
                bool isRenovation = await CheckRenovation(rom.Id, dt);
                if (!isFree || !isRenovation)
                    return false;

                if (mergingRoom != null)
                {
                    bool isFreeMerging = await LoadExams(mergingRoom.Id, dt);
                    bool isRenovation1 = await CheckRenovation(mergingRoom.Id, dt);

                    if (!isFreeMerging || !isRenovation1)
                        return false;
                }
            }
            return true;

        }
    }
}
