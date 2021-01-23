using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using PSW_Wpf_app.ViewModel;
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
    /// Interaction logic for RelocationEquipmentView.xaml
    /// </summary>
    public partial class RelocationEquipmentView : Window
    {
        RelocationEquipmentViewModel context = new RelocationEquipmentViewModel();

        public RelocationEquipmentView()
        {
            InitializeComponent();
            DataContext = context;

        }


        private void equipments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            context.LoadRoomByEquipment((Equipment)equipments.SelectedItem);
        }

        private void room_from_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room room_from = (Room)rooms_from.SelectedItem;
            if (room_from != null)
                context.LoadRoom(room_from);
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            if (times.SelectedItem == null)
            {

                DateTime date = (DateTime)Picker.SelectedDate;
                DateTime time = (DateTime)startTimePicker.SelectedTime;


                DateTime dt = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
                try
                {

                    context.SearchRoomAvailability((rooms_from.SelectedItem as Room).Id, (rooms_to.SelectedItem as Room).Id, dt, (equipments.SelectedItem as Equipment).Name.ToString());


                }
                catch
                {
                    MessageBox.Show("error SearchRoomAvailability");
                }
            }
            else
            {
                DateTime dt = (DateTime)times.SelectedItem;

                try
                {
                    context.SearchRoomAvailability((rooms_from.SelectedItem as Room).Id, (rooms_to.SelectedItem as Room).Id, dt, (equipments.SelectedItem as Equipment).Name.ToString()  /*+ ", " + amount.Text*/);
                }
                catch
                {
                    MessageBox.Show("error SearchRoomAvailability");
                }



            }
        }
        
        
    }
}
