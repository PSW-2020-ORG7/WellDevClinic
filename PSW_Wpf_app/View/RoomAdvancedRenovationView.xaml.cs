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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
