using PSW_Wpf_app.Model;
using PSW_Wpf_app.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RoomAdvancedRenovationView.xaml
    /// </summary>
    public partial class RoomAdvancedRenovationView : Window
    {
        private FloorElement floor;
        private RoomAdvancedRenovationViewModel context;
        public RoomAdvancedRenovationView(FloorElement floor)
        {
            context = new RoomAdvancedRenovationViewModel(floor);

            InitializeComponent();
            this.floor = floor;
            DataContext = context;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FloorElement f = null;
            DateTime date1 = (DateTime)Picker1.SelectedDate;
            DateTime date2 = (DateTime)Picker2.SelectedDate;

            string tipRenoviranja = (string)((ComboBoxItem)renovations.SelectedItem).Content;
            if (tipRenoviranja.CompareTo("Spajanje") == 0)
            {
                f = (FloorElement)rooms.SelectedItem;

            }

            bool IsScheduled = await context.Scheduling(date1, date2, tipRenoviranja, f);
            if (IsScheduled)
            {
                MessageBox.Show("You have successfully scheduled renovation!");
            }
            else
            {

                context.GetAlternativeExaminations(f, date1, date2);
                MessageBox.Show("Choosen term is busy, please choose an alternative!");
                alter.IsEnabled = true;
            }
        }

        private void renovations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string str = (string)((ComboBoxItem)((ComboBox)e.Source).SelectedItem).Content;
            if (str.CompareTo("Podela") == 0)

            {
                rooms.IsEnabled = false;

            }

            else
            {
                rooms.IsEnabled = true;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date1 = (DateTime)Picker1.SelectedDate;
            DateTime date2 = (DateTime)Picker2.SelectedDate;
            DateTime date3 = (DateTime)alter.SelectedItem;

            double days = (date2 - date1).TotalDays;
            Picker1.SelectedDate = date3;
            Picker2.SelectedDate = date3.AddDays(days);
        }
    }
}
