using PSW_Wpf_app.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
        public BindingList<Tuple<DateTime, DateTime>> Alternative = new BindingList<Tuple<DateTime, DateTime>>();
        public BasicRenovationView(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (scheduleRenovationGrid.SelectedItem == null)
            {
                DateTime start = new DateTime(((DateTime)startDatePicker.SelectedDate).Year, ((DateTime)startDatePicker.SelectedDate).Month, ((DateTime)startDatePicker.SelectedDate).Day, ((DateTime)startTimePicker.SelectedTime).Hour, ((DateTime)startTimePicker.SelectedTime).Minute, ((DateTime)startTimePicker.SelectedTime).Second);
                DateTime end = new DateTime(((DateTime)endDatePicker.SelectedDate).Year, ((DateTime)endDatePicker.SelectedDate).Month, ((DateTime)endDatePicker.SelectedDate).Day, ((DateTime)endTimePicker.SelectedTime).Hour, ((DateTime)endTimePicker.SelectedTime).Minute, ((DateTime)endTimePicker.SelectedTime).Second);

                string tekst = RenovationText.Text;

                LoadExams(start, end);
            }
            else
            {
                ScheduleAlternative();
            }
        }

        private async void ScheduleAlternative()
        {
            Tuple<DateTime, DateTime> chosen = (Tuple<DateTime, DateTime>)scheduleRenovationGrid.SelectedItem;
            Renovation r1 = new Renovation();
            r1.Room = await WpfClient.GetRoomById(id);
            r1.Period = new Period() { StartDate = chosen.Item1, EndDate = chosen.Item2 };
            r1.Description = RenovationText.Text;

            r1 = await WpfClient.Save(r1);

            MessageBox.Show("Renovation in successfuly scheduled.");
        }

        private async void LoadExams( DateTime start, DateTime end)
        {
            List<Examination> list = await WpfClient.GetExaminationsByRoomAndPeriodForAlternative(id, start, end);
            List<Tuple<DateTime, DateTime>> alt = new List<Tuple<DateTime, DateTime>>();
            if (list.Count != 0)
            {
                int i = 5;
                while(i > 0)
                {
                    start = start.AddDays(1);
                    end = end.AddDays(1);
                    List<Examination> temp = await WpfClient.GetExaminationsByRoomAndPeriodForAlternative(id, start, end);
                    if (temp.Count == 0)
                    {
                        alt.Add(new Tuple<DateTime, DateTime>(start, end));
                        i--;
                    }
                }
                Alternative = new BindingList<Tuple<DateTime, DateTime>>(alt);


            }
            else
            {
                Renovation r1 = new Renovation();
                r1.Room = await WpfClient.GetRoomById(id);
                r1.Period = new Period() { StartDate = start, EndDate = end };
                r1.Description = RenovationText.Text;

                r1 = await WpfClient.Save(r1);

                MessageBox.Show("Renovation in successfuly scheduled.");
            }
        }
    }
}
