using PSW_Wpf_app.Model;
using System.Windows;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for RoomStuffView.xaml
    /// </summary>
    public partial class RoomStuffView : Window
    {
        FloorElement floorElement = new FloorElement();
        public RoomStuffView(FloorElement f)
        {
            
            InitializeComponent();
            floorElement = f;
            userEqipmentAndDrugs.Content = new RoomOverviewView(f);
        }

        private void RoomOverviewClick(object sender, RoutedEventArgs e)
        {
            this.userEqipmentAndDrugs.Content = new RoomOverviewView(floorElement);
        }

        private void ScheduledAppointmentsClick(object sender, RoutedEventArgs e)
        {
            userEqipmentAndDrugs.Content = new RoomAppointmentsView(floorElement);
        }

        private void RoomRenovationsClick(object sender, RoutedEventArgs e)
        {
            userEqipmentAndDrugs.Content = new RoomRenovationsView(floorElement);
        }

        private void EquipmentRelocationClick(object sender, RoutedEventArgs e)
        {
            userEqipmentAndDrugs.Content = new RoomEquipmentRelocationView(floorElement);
        }
    }
}
