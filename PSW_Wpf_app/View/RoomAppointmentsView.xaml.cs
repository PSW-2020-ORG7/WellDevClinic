using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for RoomAppointmentsView.xaml
    /// </summary>
    public partial class RoomAppointmentsView : UserControl
    {
        BindingList<UpcomingExamination> examinations;
        List<BusinessDay> businessDays = new List<BusinessDay>();
        public RoomAppointmentsView(FloorElement floor)
        {
            InitializeComponent();
            GetExaminations(floor);
        }

        public async void GetExaminations(FloorElement floor)
        {
            examinations = new BindingList<UpcomingExamination>(await WpfClient.GetAllUpcomingExaminations());
            businessDays = await WpfClient.GetAllBusinessDay();
            BindingList<UpcomingExamination> examinationsInRoom = new BindingList<UpcomingExamination>();
            foreach (BusinessDay b in businessDays)
            {
                if (b.Room.Id.Equals(floor.RoomId))
                    FindDoctorsExaminations(examinationsInRoom, b);
            }
            scheduledAppointments.ItemsSource = examinationsInRoom;
        }

        private void FindDoctorsExaminations(BindingList<UpcomingExamination> examinationsInRoom, BusinessDay b)
        {
            foreach (UpcomingExamination e in examinations)
            {

                if (e.Doctor.Id.Equals(b.Doctor.Id) && e.Period.StartDate.Date == b.Shift.StartDate.Date && e.Period.StartDate >= DateTime.Now.Date && !e.Canceled)
                {
                    e.Room = b.Room;
                    examinationsInRoom.Add(e);
                }
            }
        }

        private async void Cancel_Click(object sender, RoutedEventArgs e)
        {
            UpcomingExamination examination = (UpcomingExamination)scheduledAppointments.SelectedItem;
            WpfClient.CancelExamination(examination.Id);
            MessageBox.Show("You have successfully canceled examination !");
        }
    }
}
