using PSW_Wpf_app.Model;
using System.Windows.Controls;

namespace PSW_Wpf_app.View
{
    /// <summary>
    /// Interaction logic for RoomRenovationsView.xaml
    /// </summary>
    public partial class RoomRenovationsView : UserControl
    {
        private FloorElement floor;

        public RoomRenovationsView(FloorElement floor)
        {
            InitializeComponent();
            this.floor = floor;
        }

        private void AdvancedRenovation_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RoomAdvancedRenovationView view = new RoomAdvancedRenovationView(floor);
            view.Show();
        }
    }
}
