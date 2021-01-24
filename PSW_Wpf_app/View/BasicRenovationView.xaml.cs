using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for BasicRenovationView.xaml
    /// </summary>
    public partial class BasicRenovationView : Window
    {
        int id;
        public BasicRenovationView(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void ScheduleBasicRenovationClick(object sender, RoutedEventArgs e)
        {
            if (scheduleRenovationGrid.SelectedItem == null)
            {
                DateTime start = new DateTime(((DateTime)startDatePicker.SelectedDate).Year, ((DateTime)startDatePicker.SelectedDate).Month, ((DateTime)startDatePicker.SelectedDate).Day, ((DateTime)startTimePicker.SelectedTime).Hour, ((DateTime)startTimePicker.SelectedTime).Minute, ((DateTime)startTimePicker.SelectedTime).Second);
                DateTime end = new DateTime(((DateTime)endDatePicker.SelectedDate).Year, ((DateTime)endDatePicker.SelectedDate).Month, ((DateTime)endDatePicker.SelectedDate).Day, ((DateTime)endTimePicker.SelectedTime).Hour, ((DateTime)endTimePicker.SelectedTime).Minute, ((DateTime)endTimePicker.SelectedTime).Second);
                Period period = new Period(start, end);

                LoadExams(period);
            }
            else
            {
                ScheduleAlternative();
            }
        }

        private async void ScheduleAlternative()
        {
            Period chosenPeriod = (Period)scheduleRenovationGrid.SelectedItem;
            Renovation renovation = new Renovation();
            renovation.Room = await WpfClient.GetRoomById(id);
            renovation.Period = new Period(chosenPeriod.StartDate, chosenPeriod.EndDate);
            renovation.Description = RenovationText.Text;
            renovation.RenovationStatus = RenovationStatus.Zakazano;

            await WpfClient.Save(renovation);
            await MarkRenovationDays(renovation);

            MessageBox.Show("Renovation in successfuly scheduled.");
        }

        private async void LoadExams(Period period)
        {
            Room room = await LoadRoom(id);
            List<UpcomingExamination> list = await WpfClient.GetExaminationsByRoomAndPeriod(room, period);
            Boolean isFree =  await CheckRenovationsSchedule(period, room);

            List<Period> alt = new List<Period>();
            if (list.Count != 0 || isFree == false)
            {
                int i = 5;
                while (i > 0)
                {
                    period.StartDate = period.StartDate.AddDays(1);
                    period.EndDate = period.EndDate.AddDays(1);
                    List<UpcomingExamination> temp = await WpfClient.GetExaminationsByRoomAndPeriod(room, period);
                    Boolean isFreeAlternative = await CheckRenovationsScheduleAlternative(period, room);
                    if (temp.Count == 0 && isFreeAlternative == true)
                    {
                        alt.Add(new Period(period.StartDate, period.EndDate));
                        i--;
                    }
                }
                scheduleRenovationGrid.ItemsSource = alt;

            }
            else
            {
                Renovation renovation = new Renovation();
                renovation.Room = room;
                renovation.Period = period;
                renovation.Description = RenovationText.Text;
                renovation.RenovationStatus = RenovationStatus.Zakazano;

                await WpfClient.Save(renovation);
                await MarkRenovationDays(renovation);

                MessageBox.Show("Renovation in successfuly scheduled.");
            }
        }

        private static async Task<Boolean> CheckRenovationsSchedule(Period period, Room room)
        {
            List<Renovation> renovations = await WpfClient.GetAllRenovation();
            foreach (Renovation r in renovations)
            {
                if (room.Id == r.Room.Id && r.Period.StartDate.Date >= period.StartDate.Date && period.EndDate.Date >= r.Period.EndDate.Date)
                    return CheckRenovationStatus(r);
            }
            return true;
        }

        private static async Task<Boolean> CheckRenovationsScheduleAlternative(Period period, Room room)
        {
            List<Renovation> renovations = await WpfClient.GetAllRenovation();
            foreach (Renovation r in renovations)
            {
                if (room.Id == r.Room.Id && r.Period.StartDate.Date == period.EndDate.Date)
                    return CheckRenovationStatus(r);
                else if (room.Id == r.Room.Id && period.StartDate.Date == r.Period.EndDate.Date)
                    return CheckRenovationStatus(r);
                else if (room.Id == r.Room.Id && period.StartDate.Date == r.Period.StartDate.Date)
                    return CheckRenovationStatus(r);

                else if (room.Id == r.Room.Id && period.EndDate.Date == r.Period.EndDate.Date)
                    return CheckRenovationStatus(r);

            }
            return true;
        }

        private static Boolean CheckRenovationStatus(Renovation r)
        {
            if (r.RenovationStatus == RenovationStatus.Zakazano || r.RenovationStatus == RenovationStatus.Traje)
                return  false;
            return true;
        }


        private static async Task MarkRenovationDays(Renovation renovation)
        {
            List<BusinessDay> buss = await WpfClient.GetAllBusinessDay();
            List<Period> periods = new List<Period>();

            foreach (BusinessDay b in buss)
            {
                if (b.Room.Id == renovation.Room.Id && renovation.Period.StartDate.Date <= b.Shift.StartDate.Date && b.Shift.StartDate.Date <= renovation.Period.EndDate.Date)
                {
                    DateTime date = b.Shift.EndDate;
                    DateTime startDate = b.Shift.StartDate;
                    while (startDate <= date)
                    {
                        b.Shift.EndDate = startDate.AddMinutes(30);
                        periods.Add(new Period(startDate, b.Shift.EndDate));
                        startDate = startDate.AddMinutes(30);
                    }
                    await WpfClient.MarkAsOccupied(periods, b.Id);
                }
            }
        }

        public async Task<Room> LoadRoom(int id)
        {
            return await WpfClient.GetRoomById(id);
        }
    }
}
