using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
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
        BindingList<Examination> examinations;
        List<BusinessDay> businessDays = new List<BusinessDay>();
        public RoomAppointmentsView(FloorElement floor)
        {
            InitializeComponent();
            GetExaminations(floor);
        }

        public async void GetExaminations(FloorElement floor)
        {
            examinations = new BindingList<Examination>(await WpfClient.GetAllExaminations());
            businessDays = await WpfClient.GetAllBusinessDay();
            BindingList<Examination> examinationsInRoom = new BindingList<Examination>();
            foreach (BusinessDay b in businessDays)
            {
                if (b.room.Id.Equals(floor.RoomId))
                    FindDoctorsExaminations(examinationsInRoom, b);
            }
            scheduledAppointments.ItemsSource = examinationsInRoom;
        }

        private void FindDoctorsExaminations(BindingList<Examination> examinationsInRoom, BusinessDay b)
        {
            foreach (Examination e in examinations)
            {
                if (e.Doctor.Id.Equals(b.doctor.Id) && e.Canceled != true)
                {
                    e.Room = b.room;
                    examinationsInRoom.Add(e);
                }
            }
        }

        private async void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Examination examination = (Examination)scheduledAppointments.SelectedItem;
            WpfClient.CancelExamination(examination.Id);
          /*  if(scheduledAppointments.SelectedItem != null)
            {
                scheduledAppointments.Items.Remove(scheduledAppointments.SelectedItem);
            }*/
        }
    }
}
